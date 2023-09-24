using internTask.DAL.Helper;
using internTask.DAL.Models.Helper;
using internTask.DAL.Models.QuestionEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Models
{
    public class ApplicationForm
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public visibilityState PhoneNumber { get; set; }
        public visibilityState CurrentResidence { get; set; }
        public visibilityState IdNumber { get; set; }
        public visibilityState DateOfBirth { get; set; }
        public visibilityState Gender { get; set; }
        public ICollection<Question> Questions { get; set; }=new HashSet<Question>();
        public int ProgramId { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public ProgramModel? ProgramModel { get; set; }

    }
}
