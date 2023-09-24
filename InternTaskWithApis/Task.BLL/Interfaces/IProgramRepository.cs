using internTask.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.BLL.Interfaces
{
    public interface IProgramRepository:IGenericRepository<ProgramModel>
    {
       Task AddProgramSkills(int ProgramId, List<int> SkillsId);
       Task UpdateProgramSkills(int programId, List<int> updatedSkillIds);
    }
}
