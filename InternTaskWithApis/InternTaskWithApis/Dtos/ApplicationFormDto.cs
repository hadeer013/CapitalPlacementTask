using internTask.DAL.Helper;
using InternTaskWithApis.Dtos.QuestionDtoEntities;
using System.ComponentModel.DataAnnotations;

namespace InternTaskWithApis.Dtos
{
    public class ApplicationFormDto
    {
        public string ImageUrl { get; set; }
        public visibilityState PhoneNumber { get; set; }
       
        public visibilityState CurrentResidence { get; set; }
        
        public visibilityState IdNumber { get; set; }
        
        public visibilityState DateOfBirth { get; set; }
        public visibilityState Gender { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public int ProgramId { get; set; }
    }
}
