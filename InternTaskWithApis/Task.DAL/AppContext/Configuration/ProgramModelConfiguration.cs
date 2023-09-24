using internTask.DAL.Helper;
using internTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.AppContext.Configuration
{
    public class ProgramModelConfiguration : IEntityTypeConfiguration<ProgramModel>
    {
        public void Configure(EntityTypeBuilder<ProgramModel> builder)
        {
            builder.Property(o => o.ProgramType)
           .HasConversion(oStatus => oStatus.ToString(),
            oStatus => (ProgramType)Enum.Parse(typeof(ProgramType), oStatus)); 
            
            builder.Property(o => o.MinQualification)
           .HasConversion(oStatus => oStatus.ToString(),
            oStatus => (Qualifications)Enum.Parse(typeof(Qualifications), oStatus));

            builder.OwnsOne(o => o.Location, Location => Location.WithOwner());



        }
    }
}
