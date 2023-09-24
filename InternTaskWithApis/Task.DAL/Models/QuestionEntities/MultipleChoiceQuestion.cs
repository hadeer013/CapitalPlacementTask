using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Models.QuestionEntities
{
    [Table("MultipleChoiceQuestion")]

    public class MultipleChoiceQuestion : Question, QuestionsWithChoices
    {
        public MultipleChoiceQuestion()
        {
            QuestionType = QuestionType.MultipleChoice;
        }

       

        public ICollection<QuestionChoice> QuestionChoices { get; set; }=new HashSet<QuestionChoice>();
        
    }
}
