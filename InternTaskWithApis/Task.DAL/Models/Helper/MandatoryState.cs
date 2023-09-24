using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Models.Helper
{
    public enum MandatoryState
    {
        [EnumMember(Value = "Mandatory")]
        Mandatory,
        [EnumMember(Value = "Optional")]
        Optional
    }
}
