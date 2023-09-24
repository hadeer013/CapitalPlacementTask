using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using internTask.DAL.Helper;
using internTask.DAL.Helper.LocationEntities;

namespace internTask.DAL.Models
{
    public class ProgramModel
    {
        public int Id { get; set; }
        
        public string? Title { get; set; }//required
        public string? Summary { get; set; }
       
        public string? Description { get; set; }//required
        public string? ProgramBenefits { get; set; }
        public string? ApplicationCriteria { get; set; }
        public ProgramType ProgramType { get; set; }
        public DateOnly ProgramStart { get; set; }
        public DateOnly ApplicationOpen { get; set; }
        public DateOnly ApplicationClose { get; set; }
        public int Duration { get; set; }// duration in weeks
        public Qualifications MinQualification { get; set; }
        public int MaxNumOfApplication { get; set; }
        public Location? Location { get; set; }
        public ApplicationForm? ApplicationForm { get; set; }
        public ICollection<ProgramSkill> programSkills { get; set; } = new HashSet<ProgramSkill>();
    }
}
