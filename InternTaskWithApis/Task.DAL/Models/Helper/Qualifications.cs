using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Helper
{
    public enum Qualifications
    {
        [EnumMember(Value = "Associate")]
        Associate,
        [EnumMember(Value = "Bachelor")]
        Bachelor,
        [EnumMember(Value = "Master")]
        Master,
        [EnumMember(Value = "Doctorate")]
        Doctorate,
        [EnumMember(Value = "PostgraduateDiploma")]
        PostgraduateDiploma
    }
}
