using internTask.DAL.Models.QuestionEntities;

namespace InternTaskWithApis.Dtos.updateQuestionDtoEntities
{
    public class UpdateQuestionDto
    {
        public int Id { get; set; }
        public QuestionType QuestionType { get; set; }
        public string? QuestionTitle { get; set; }
    }
}
