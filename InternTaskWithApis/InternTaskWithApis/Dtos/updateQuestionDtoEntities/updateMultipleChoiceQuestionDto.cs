namespace InternTaskWithApis.Dtos.updateQuestionDtoEntities
{
    public class updateMultipleChoiceQuestionDto:UpdateQuestionDto
    {
        public ICollection<updateQuestionChoiceDto> UpdateQuestionChoiceDtos { get; set; }=new HashSet<updateQuestionChoiceDto>();
    }
}
