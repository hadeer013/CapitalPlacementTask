using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Models
{
    public class ProgramSkill
    {
        public int ProgramId { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public ProgramModel? Program { get; set; }

        public int SkillId { get; set; }
        [ForeignKey(nameof(SkillId))]
        public Skill? Skill { get; set; }
    }
}
