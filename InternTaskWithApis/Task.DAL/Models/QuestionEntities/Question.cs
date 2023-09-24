using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Models.QuestionEntities
{
    public class Question
    {
        public int Id { get; set; }
        public QuestionType QuestionType { get; set; }
        public string? QuestionTitle { get; set; }
        public int ApplicationId { get; set; }

        [ForeignKey(nameof(ApplicationId))]
        public ApplicationForm? ApplicationForm { get; set; }
    }
}
