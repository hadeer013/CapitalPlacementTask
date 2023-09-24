using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Helper
{
    public enum visibilityState
    {
        [EnumMember(Value = "Show")]
        Show,
        [EnumMember(Value = "Hide")]
        Hide
    }
}
