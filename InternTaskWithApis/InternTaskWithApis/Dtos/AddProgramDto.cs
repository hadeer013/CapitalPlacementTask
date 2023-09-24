using internTask.DAL.Helper.LocationEntities;
using internTask.DAL.Helper;
using internTask.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace InternTaskWithApis.Dtos
{
    public class AddProgramDto
    {
        [Required]
        public string? Title { get; set; }
        public string? Summary { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? ProgramBenefits { get; set; }
        public string? ApplicationCriteria { get; set; }
        [Required]
        public ProgramType ProgramType { get; set; }
        public DateOnly ProgramStart { get; set; }
        [Required]
        public DateOnly ApplicationOpen { get; set; }
        [Required]
        public DateOnly ApplicationClose { get; set; }
        public int Duration { get; set; }// duration in weeks
        public Qualifications MinQualification { get; set; }
        public int MaxNumOfApplication { get; set; }
        [Required]
        public Location? Location { get; set; }
        public List<int> SkillIds { get; set; } = new List<int>();
    }
}
