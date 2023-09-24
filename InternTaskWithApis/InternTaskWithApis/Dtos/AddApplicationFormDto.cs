using internTask.DAL.Helper;
using internTask.DAL.Models.QuestionEntities;
using InternTaskWithApis.Dtos.QuestionDtoEntities;
using System.ComponentModel.DataAnnotations;

namespace InternTaskWithApis.Dtos
{
    public class AddApplicationFormDto
    {
        public IFormFile? Image { get; set; }
        [Required]
        public visibilityState PhoneNumber { get; set; }
        [Required]
        public visibilityState CurrentResidence { get; set; }
        [Required]
        public visibilityState IdNumber { get; set; }
        [Required]
        public visibilityState DateOfBirth { get; set; }
        [Required]
        public visibilityState Gender { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public int ProgramId { get; set; }
    }
}
