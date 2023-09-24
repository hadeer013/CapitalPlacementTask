using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Models.QuestionEntities
{
    [Table("DropdownQuestion")]

    public class DropdownQuestion : Question, QuestionsWithChoices
    {
        public DropdownQuestion()
        {
            QuestionType = QuestionType.Dropdown;
        }

        public ICollection<QuestionChoice> QuestionChoices { get; set; } = new HashSet<QuestionChoice>();

    }
}
