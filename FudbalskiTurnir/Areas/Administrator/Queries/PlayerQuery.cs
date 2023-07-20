using FudbalskiTurnir.Infrastruktura;
using FudbalskiTurnir.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Areas.Administrator.Queries
{
    public class PlayerQuery
    {
        private readonly FudbalskiTurnirContext context;
        public PlayerQuery(FudbalskiTurnirContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await context.Players.Include(x => x.Teams).ToListAsync();
        }
        public async Task<Player> GetPlayerById(int id)
        {
            var player = await context.Players.Include(x => x.Teams).FirstOrDefaultAsync(x => x.Id == id);
            return player;
        }

        public async Task AddItem(Player model)
        {
            context.Players.Add(new Player { FirstName = model.FirstName, LastName = model.LastName, TeamId = model.TeamId });
            await context.SaveChangesAsync();

        }

        public async Task DeleteItem(int id)
        {
            var player = await GetPlayerById(id);
            context.Players.Remove(player);
            await context.SaveChangesAsync();

        }

        public async Task UpdateItem(Player model)
        {
            var item = await GetPlayerById(model.Id);
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;
            item.TeamId = model.TeamId;
            await context.SaveChangesAsync();

        }
    }
}
