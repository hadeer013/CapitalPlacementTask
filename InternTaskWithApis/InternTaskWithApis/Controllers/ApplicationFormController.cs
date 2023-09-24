using internTask.BLL.Interfaces;
using internTask.DAL.Models;
using internTask.DAL.Models.QuestionEntities;
using InternTaskWithApis.Document;
using InternTaskWithApis.Dtos;
using InternTaskWithApis.Dtos.QuestionDtoEntities;
using InternTaskWithApis.Dtos.updateQuestionDtoEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;

namespace InternTaskWithApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IProgramRepository programRepo;
        private readonly IConfiguration configuration;
        private readonly IGenericRepository<ApplicationForm> applicationRepo;
        private readonly IGenericRepository<Question> questionRepo;
        private readonly IGenericRepository<QuestionChoice> qChoiceRepo;

        public ApplicationFormController(IProgramRepository programRepo, IConfiguration configuration,
            IGenericRepository<ApplicationForm> applicationRepo,IGenericRepository<Question> QuestionRepo,
            IGenericRepository<QuestionChoice> QChoiceRepo)
        {
            this.programRepo = programRepo;
            this.configuration = configuration;
            this.applicationRepo = applicationRepo;
            questionRepo = QuestionRepo;
            qChoiceRepo = QChoiceRepo;
        }

        //create new application form for a program
        [HttpPost("MakeNewApplicationForm")]
        public async Task<ActionResult> MakeNewApplicationForm([FromForm] AddApplicationFormDto formDto)
        {
            if (formDto == null) return BadRequest();
            var program = await programRepo.GetWithId(formDto.ProgramId);
            if (program == null) return BadRequest();

            string ImageUrl=null;
            if (formDto.Image != null)
            {
                ImageUrl = DocumetSettings.UploadFile(formDto.Image, "Imgs");
                //user.ImageUrl = ImageUrl;/*$"files/Imgs/{ImageUrl}";*/
            }

            var applicationForm = new ApplicationForm()
            {
                CurrentResidence = formDto.CurrentResidence,
                DateOfBirth = formDto.DateOfBirth,
                Gender = formDto.Gender,
                IdNumber = formDto.IdNumber,
                PhoneNumber = formDto.PhoneNumber,
                ProgramId = formDto.ProgramId,
                ImageUrl = string.IsNullOrEmpty(ImageUrl) ? null : $"{configuration["BaseUrl"]}{ImageUrl}",
            };
            var Entity = await applicationRepo.Add(applicationForm);

            if (formDto.Questions.Count != 0)
            {
                foreach (var question in formDto.Questions)
                {
                    // Handle different question types here
                    switch (question.QuestionType)
                    {
                        case QuestionType.MultipleChoice:
                            var MCQDto = (MultipleChoicesQuestionDto)question;
                            var MCQ = new MultipleChoiceQuestion()
                            {
                                QuestionTitle = MCQDto.QuestionTitle,
                                QuestionType = MCQDto.QuestionType,
                                ApplicationId = Entity.Id
                            };
                            var mcqEntity = await questionRepo.Add(MCQ);
                            if (MCQDto.Choices.Count != 0)
                            {
                                foreach (var choice in MCQDto.Choices)
                                {
                                    var QuestionChoice = new QuestionChoice()
                                    {
                                        Choice = choice,
                                        QuestionId = mcqEntity.Id
                                    };
                                    await qChoiceRepo.Add(QuestionChoice);
                                }

                            }
                            else return BadRequest("Must specify the choices to the question of type MCQ");

                            break;

                        case QuestionType.Paragraph:
                            var paragraphQuestionDto = (ParagraphQuestionDto)question;
                            var paragragh = new ParagraghQuestion()
                            {
                                QuestionTitle = paragraphQuestionDto.QuestionTitle,
                                QuestionType = paragraphQuestionDto.QuestionType,
                                ApplicationId = Entity.Id
                            };
                            await questionRepo.Add(paragragh);  
                            break;

                        case QuestionType.YesNo:
                            var yesNoQuestionDto = (YesNoQuestionDto)question;
                            var yesNoQuestion = new YesNoQuestion()
                            {
                                QuestionTitle = yesNoQuestionDto.QuestionTitle,
                                QuestionType = yesNoQuestionDto.QuestionType,
                                ApplicationId = Entity.Id
                            };
                            await questionRepo.Add(yesNoQuestion);
                            break;

                        case QuestionType.Dropdown:
                            var dropdownQuestionDto = (DropdownQuestionDto)question;
                            var dropdownQuestion = new DropdownQuestion()
                            {
                                QuestionTitle = dropdownQuestionDto.QuestionTitle,
                                QuestionType = dropdownQuestionDto.QuestionType,
                                ApplicationId = Entity.Id
                            };
                            
                            var dropdownEntity = await questionRepo.Add(dropdownQuestion);
                            if (dropdownQuestionDto.items.Count != 0)
                            {
                                foreach (var item in dropdownQuestionDto.items)
                                {
                                    var QuestionChoice = new QuestionChoice()
                                    {
                                        Choice = item,
                                        QuestionId = dropdownEntity.Id
                                    };
                                    await qChoiceRepo.Add(QuestionChoice);
                                }

                            }
                            else return BadRequest("Must specify the choices to the question of type Dropdown");

                            break;

                        default:
                            break;
                    }
                }
            }
            //return
            return Ok(Entity);
        }
        [HttpGet("GetApplication/{id}")]
        public async Task<ActionResult> GetApplicationById(int id)
        {
            var application =await applicationRepo.GetWithId(id);
            if (application == null) return NotFound();
            return Ok(application);
        }


        
        // Update an existing application form
        [HttpPut("UpdateApplicationForm")]
        public async Task<ActionResult> UpdateApplicationForm([FromForm] UpdateApplicationFormDto updateFormDto)
        {
            if (updateFormDto == null)
            {
                return BadRequest("Invalid input data.");
            }

            // Check if the application form exists
            var existingForm = await applicationRepo.GetWithId(updateFormDto.Id);
            if (existingForm == null)
            {
                return NotFound("Application form not found.");
            }

            // Update common application form properties
            existingForm.CurrentResidence = updateFormDto.CurrentResidence;
            existingForm.DateOfBirth = updateFormDto.DateOfBirth;
            existingForm.Gender = updateFormDto.Gender;
            existingForm.IdNumber = updateFormDto.IdNumber;
            existingForm.PhoneNumber = updateFormDto.PhoneNumber;

            // Update or clear the image URL
            if (updateFormDto.Image != null)
            {
                var imageUrl = DocumetSettings.UploadFile(updateFormDto.Image, "Imgs");
                existingForm.ImageUrl = string.IsNullOrEmpty(imageUrl) ? null : $"{configuration["BaseUrl"]}{imageUrl}";
            }
            else
            {
                existingForm.ImageUrl = null;
            }

            // Update the application form entity
            await applicationRepo.Update(existingForm);

            // Handle updating questions (similar to your previous code)
            //**********************
            if (updateFormDto.Questions.Count != 0)
            {
                foreach (var question in updateFormDto.Questions)
                {
                    // Handle different question types here
                    switch (question.QuestionType)
                    {
                        case QuestionType.MultipleChoice:
                            var MCQDto = (updateMultipleChoiceQuestionDto)question;
                            var MCQ = await questionRepo.GetWithId(MCQDto.Id);

                            MCQ.QuestionTitle = MCQDto.QuestionTitle;
                            MCQ.QuestionType = MCQDto.QuestionType;

                            await questionRepo.Update(MCQ);
                            if (MCQDto.UpdateQuestionChoiceDtos.Count != 0)
                            {
                                foreach (var choice in MCQDto.UpdateQuestionChoiceDtos)
                                {
                                    var ch=await qChoiceRepo.GetWithId(choice.Id);
                                    ch.Choice = choice.Choice;
                                    
                                    await qChoiceRepo.Update(ch);
                                }
                            }
                            else return BadRequest("Must specify the choices to the question of type MCQ");

                            break;

                        case QuestionType.Paragraph:
                            var paragraphQuestionDto = (updateParagraphQuestionDto)question;

                            var paragragh = await questionRepo.GetWithId(paragraphQuestionDto.Id);

                            paragragh.QuestionTitle = paragraphQuestionDto.QuestionTitle;
                            
                            await questionRepo.Update(paragragh);
                            break;

                        case QuestionType.YesNo:
                            var yesNoQuestionDto = (updateYesNoQuestionDto)question;
                            var yesNoQuestion = await questionRepo.GetWithId(yesNoQuestionDto.Id);

                            yesNoQuestion.QuestionTitle = yesNoQuestionDto.QuestionTitle;
                            
                            await questionRepo.Update(yesNoQuestion);
                            break;

                        case QuestionType.Dropdown:
                            var dropdownQuestionDto = (updateDropdownQuestionDto)question;
                            var dropdownQuestion = await questionRepo.GetWithId(dropdownQuestionDto.Id);

                            dropdownQuestion.QuestionTitle = dropdownQuestionDto.QuestionTitle;
                            dropdownQuestion.QuestionType = dropdownQuestionDto.QuestionType;
                            

                            await questionRepo.Update(dropdownQuestion);
                            if (dropdownQuestionDto.UpdateQuestionChoiceDtos.Count != 0)
                            {
                                foreach (var item in dropdownQuestionDto.UpdateQuestionChoiceDtos)
                                {

                                    var QuestionChoice = await qChoiceRepo.GetWithId(item.Id);

                                    QuestionChoice.Choice = item.Choice;
                                    await qChoiceRepo.Update(QuestionChoice);
                                }
                            }
                            else return BadRequest("Must specify the choices to the question of type Dropdown");

                            break;

                        default:
                            break;
                    }
                }
                //**********************
            }    // Return updated application form
                return Ok(existingForm);
        }
    }
}
