using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Models.QuestionEntities
{
    [Table("ParagraghQuestion")]

    public class ParagraghQuestion : Question
    {
        public ParagraghQuestion()
        {
            QuestionType = QuestionType.Paragraph;
        }
    }
}
