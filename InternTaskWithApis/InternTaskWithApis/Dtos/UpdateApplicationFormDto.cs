using internTask.DAL.Helper;
using internTask.DAL.Models.QuestionEntities;
using internTask.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using InternTaskWithApis.Dtos.updateQuestionDtoEntities;

namespace InternTaskWithApis.Dtos
{
    public class UpdateApplicationFormDto
    {
        public int Id { get; set; }
        public IFormFile? Image { get; set; }
        public visibilityState PhoneNumber { get; set; }
        public visibilityState CurrentResidence { get; set; }
        public visibilityState IdNumber { get; set; }
        public visibilityState DateOfBirth { get; set; }
        public visibilityState Gender { get; set; }
        public ICollection<UpdateQuestionDto> Questions { get; set; } = new HashSet<UpdateQuestionDto>();
        
    }
}
