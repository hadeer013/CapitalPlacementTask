namespace InternTaskWithApis.Dtos.updateQuestionDtoEntities
{
    public class updateDropdownQuestionDto:UpdateQuestionDto
    {
        public ICollection<updateQuestionChoiceDto> UpdateQuestionChoiceDtos { get; set; } = new HashSet<updateQuestionChoiceDto>();  
    }
}
