using FudbalskiTurnir.Infrastruktura;
using FudbalskiTurnir.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Areas.Administrator.Queries
{
    public class TeamQuery
    {
        private readonly FudbalskiTurnirContext context;
        public TeamQuery(FudbalskiTurnirContext context)
        {
            this.context = context;
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await context.Teams.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Team>> GetTeams()
        {
            return await context.Teams.ToListAsync();
        }
        
        public async Task DeleteItem(int id)
        {
            var team =  await GetTeamById(id);
            context.Teams.Remove(team);
            await context.SaveChangesAsync();

        }

        public async Task AddItem(Team model)
        {
            context.Teams.Add(new Team { Name = model.Name});
            await context.SaveChangesAsync();

        }
        public async Task UpdateItem(Team model)
        {
            var item = await GetTeamById(model.Id);
            item.Name = model.Name;
            await context.SaveChangesAsync();

        }
    }
}
