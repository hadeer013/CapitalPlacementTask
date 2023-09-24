using InternTaskWithApis.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using internTask.BLL.Interfaces;
using internTask.DAL.Helper.LocationEntities;
using internTask.DAL.Models;

namespace InternTaskWithApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramModelController : ControllerBase
    {
        private readonly IProgramRepository programRepo;

        public ProgramModelController(IProgramRepository programRepo)
        {
            this.programRepo = programRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetProgramById(int id)
        {
            var result = await programRepo.GetWithId(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("addProgram")]
        public async Task<ActionResult> AddNewProgram(AddProgramDto addProgramDto)
        {
            var location = new Location();
            if (addProgramDto.Location?.programLocation == ProgramLocation.Offline)
            {
                if (addProgramDto.Location.OnSightLocation == null) return BadRequest("Mustion mention the location");
                else
                    location.OnSightLocation = addProgramDto.Location.OnSightLocation;
            }
            else if (addProgramDto.Location?.programLocation == ProgramLocation.Remote)
                location.programLocation = ProgramLocation.Remote;
            var program = new ProgramModel()
            {
                ApplicationClose = addProgramDto.ApplicationClose,
                ApplicationCriteria = addProgramDto.ApplicationCriteria,
                ApplicationOpen = addProgramDto.ApplicationOpen,
                Description = addProgramDto.Description,
                Duration = addProgramDto.Duration,
                MaxNumOfApplication = addProgramDto.MaxNumOfApplication,
                MinQualification = addProgramDto.MinQualification,
                ProgramBenefits = addProgramDto.ProgramBenefits,
                ProgramStart = addProgramDto.ProgramStart,
                ProgramType = addProgramDto.ProgramType,
                Summary = addProgramDto.Summary,
                Title = addProgramDto.Title,
                Location = location
            };

            var entity = await programRepo.Add(program);
            await programRepo.AddProgramSkills(entity.Id, addProgramDto.SkillIds);

            return Ok(entity);//again

        }


        [HttpPut("updateProgram")]
        public async Task<ActionResult> UpdateProgram([FromQuery] int id, AddProgramDto updateProgramDto)
        {
            var existingProgram = await programRepo.GetWithId(id);
            if (existingProgram == null)
            {
                return NotFound("Program not found");
            }


            existingProgram.Title = updateProgramDto.Title;
            existingProgram.Summary = updateProgramDto.Summary;
            existingProgram.Description = updateProgramDto.Description;
            existingProgram.ProgramBenefits = updateProgramDto.ProgramBenefits;
            existingProgram.ApplicationCriteria = updateProgramDto.ApplicationCriteria;

            if (updateProgramDto.Location?.programLocation == ProgramLocation.Offline)
            {
                if (updateProgramDto.Location.OnSightLocation == null)
                {
                    return BadRequest("Must mention the location");
                }
                else
                {
                    existingProgram.Location.OnSightLocation = updateProgramDto.Location.OnSightLocation;
                    existingProgram.Location.programLocation = ProgramLocation.Offline;
                }
            }
            else if (updateProgramDto.Location?.programLocation == ProgramLocation.Remote)
            {
                existingProgram.Location.programLocation = ProgramLocation.Remote;
                existingProgram.Location.OnSightLocation = null; 
            }

            
            await programRepo.UpdateProgramSkills(existingProgram.Id, updateProgramDto.SkillIds);

           
            var updatedEntity = await programRepo.Update(existingProgram);

            return Ok(updatedEntity);
        }
    }
}
