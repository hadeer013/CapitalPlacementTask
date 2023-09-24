using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using internTask.DAL.Models;

namespace internTask.DAL.AppContext.Configuration
{
    public class ProgramSkillConfiguration : IEntityTypeConfiguration<ProgramSkill>
    {
        public void Configure(EntityTypeBuilder<ProgramSkill> builder)
        {
            builder.HasKey(pk=>new {pk.ProgramId,pk.SkillId});

            builder.HasOne(ps => ps.Skill)
                .WithMany(s => s.programSkills)
                .HasForeignKey(s => s.SkillId);

            builder.HasOne(ps => ps.Program)
                .WithMany(p => p.programSkills)
                .HasForeignKey(ps => ps.ProgramId);
        }
    }
}
