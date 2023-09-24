using internTask.DAL.Models;
using internTask.DAL.Models.QuestionEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.AppContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<ProgramModel> ProgramModels { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProgramSkill> ProgramSkills { get; set; }
        public DbSet<YesNoQuestion> YesNoQuestion { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestion { get; set; }
        public DbSet<ParagraghQuestion> ParagraghQuestion { get; set; }
        public DbSet<DropdownQuestion> DropdownQuestion { get; set; }
        public DbSet<ApplicationForm> ApplicationForms { get; set; }
    }
}
