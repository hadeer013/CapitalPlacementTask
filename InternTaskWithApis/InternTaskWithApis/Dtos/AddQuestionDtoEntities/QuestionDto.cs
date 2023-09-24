using internTask.DAL.Models.QuestionEntities;
using internTask.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTaskWithApis.Dtos.QuestionDtoEntities
{
    public class QuestionDto
    {
        public QuestionType QuestionType { get; set; }
        public string? QuestionTitle { get; set; }
    }
}
