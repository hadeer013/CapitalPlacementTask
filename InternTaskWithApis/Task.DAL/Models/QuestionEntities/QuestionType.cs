using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Models.QuestionEntities
{
    public enum QuestionType
    {
        [EnumMember(Value = "Paragraph")]
        Paragraph,
        [EnumMember(Value = "ShortAnswer")]
        ShortAnswer,
        [EnumMember(Value = "YesNo")]
        YesNo,
        [EnumMember(Value = "Dropdown")]
        Dropdown,
        [EnumMember(Value = "MultipleChoice")]
        MultipleChoice,
        [EnumMember(Value = "Date")]
        Date,
        [EnumMember(Value = "Number")]
        Number,
        [EnumMember(Value = "FileUpload")]
        FileUpload
    }
}
