using internTask.BLL.Interfaces;
using internTask.DAL.AppContext;
using internTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internTask.BLL.Repositories
{
    public class ProgramRepository : GenericRepository<ProgramModel>, IProgramRepository
    {
        private readonly ApplicationContext applicationContext;

        public ProgramRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task AddProgramSkills(int ProgramId, List<int> SkillsId)
        {
            var skills=await applicationContext.Set<Skill>().Where(s => SkillsId.Contains(s.Id)).ToListAsync();
            foreach (var value in skills)
            {
                applicationContext.Set<ProgramSkill>().Add(new ProgramSkill() { ProgramId = ProgramId, SkillId = value.Id });
            }
            await applicationContext.SaveChangesAsync();
        }

        public async Task UpdateProgramSkills(int programId, List<int> updatedSkillIds)
        {
            
            var ProgramSkills = await applicationContext.Set<ProgramSkill>()
                .Where(s=>s.ProgramId==programId).ToListAsync();
                
            var updatedSkillIdSet = new HashSet<int>(updatedSkillIds);

            
            var skillsToAdd = updatedSkillIds.Except(ProgramSkills.Select(ps => ps.SkillId));

            
            var skillsToRemove = ProgramSkills
                .Where(ps => !updatedSkillIdSet.Contains(ps.SkillId))
                .ToList();

            
            foreach (var skillIdToAdd in skillsToAdd)
            {
                applicationContext.Set<ProgramSkill>().Add(new ProgramSkill
                {
                    ProgramId = programId,
                    SkillId = skillIdToAdd
                });
            }

            // Remove program skills
            foreach (var skillToRemove in skillsToRemove)
            {
                 applicationContext.Set<ProgramSkill>().Remove(skillToRemove);
            }

            await applicationContext.SaveChangesAsync();
        }

    }
}
