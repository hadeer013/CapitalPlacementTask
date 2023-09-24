using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.DAL.Helper.LocationEntities
{
    public class Location
    {
        public ProgramLocation programLocation { get; set; } 
            = ProgramLocation.Offline;
        public string? OnSightLocation { get; set; }
    }
}
