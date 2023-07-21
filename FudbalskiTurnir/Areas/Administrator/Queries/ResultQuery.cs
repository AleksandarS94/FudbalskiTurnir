using FudbalskiTurnir.Areas.Administrator.ViewModels;
using FudbalskiTurnir.Infrastruktura;
using FudbalskiTurnir.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Areas.Administrator.Queries
{
    public class ResultQuery
    {
        private readonly FudbalskiTurnirContext context;
        public ResultQuery(FudbalskiTurnirContext context)
        {
            this.context = context;
        }
        public async Task<List<ResultViewModel>> GetResults()
        {

            var query =  from r in context.Results
                          join t1 in this.context.Teams on r.FirstTeamId equals t1.Id
                          join t2 in this.context.Teams on r.SecondTeamId equals t2.Id
                          where t1.Id == r.FirstTeamId && t2.Id == r.SecondTeamId
                          select new ResultViewModel
                          { MatchPair = $"{t1.Name} - {t2.Name}",
                            MatchResult = r.MatchResult,
                            Id = r.Id,
                            Team1Id = t1.Id,
                            Team2Id = t2.Id,
                            Team1 = r.Team1Result.ToString(),
                            Team2 = r.Team2Result.ToString(),
                          };
            var results = await query.ToListAsync();
            return results;
        }
        public void AddItem(int id1, int id2)
        {

            context.Results.Add(new Result() { 
                FirstTeamId = id1,
                SecondTeamId = id2,
                MatchResult = "0:0",
                Team1Result = 0,
                Team2Result = 0,
            });
            context.SaveChanges();
        }
        public void RemoveItems()
        {
            var allResultItems = context.Results.ToList();
            if(allResultItems.Count>0)
            {
                foreach (var item in allResultItems)
                {
                    context.Results.Remove(item);
                }
                context.SaveChanges();
            }
        }

        public void SaveResult(Result model)
        {
            var resultItem = context.Results.FirstOrDefault(x => x.Id == model.Id);
            resultItem.Team1Result = model.Team1Result;
            resultItem.Team2Result = model.Team2Result;
            resultItem.MatchResult = model.MatchResult;
            context.SaveChanges();
            
        }
    }
}
