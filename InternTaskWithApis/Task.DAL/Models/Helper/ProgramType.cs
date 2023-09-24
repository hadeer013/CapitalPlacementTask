using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Helper
{
    public enum ProgramType
    {
        [EnumMember(Value = "FullTime")]
        FullTime,
        [EnumMember(Value = "PartTime")]
        PartTime,
        [EnumMember(Value = "Internship")]
        Internship
    }
}
