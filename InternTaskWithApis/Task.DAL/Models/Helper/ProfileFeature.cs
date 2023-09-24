using internTask.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Models.Helper
{
    public class ProfileFeature
    {
        public visibilityState visibility {  get; set; }
        public MandatoryState MandatoryState { get; set; }
    }
}
