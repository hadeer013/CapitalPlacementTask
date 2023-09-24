using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Models.QuestionEntities
{
    public class QuestionChoice
    {
        public int Id { get; set; }
        public string? Choice { get; set; }
        public int QuestionId { get; set; }
        [NotMapped]
        [ForeignKey(nameof(QuestionId))]
        public QuestionsWithChoices QuestionsWithChoices { get; set; }
    }
}
