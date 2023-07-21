using FudbalskiTurnir.Areas.Administrator.Queries;
using FudbalskiTurnir.Areas.Administrator.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Areas.Administrator.Controllers
{
    [Authorize]
    public class ResultController : Controller
    {
        private readonly ResultQuery resultQuery;
        private readonly TeamQuery teamQuery;
        public static bool editDisabled = true;
        public ResultController(ResultQuery resultQuery, TeamQuery teamQuery)
        {
            this.resultQuery = resultQuery;
            this.teamQuery = teamQuery;
        }
        public async Task<IActionResult> Index()
        {
            var model = await resultQuery.GetResults();
            ViewData["editDisabled"] = editDisabled;
            return View(model);
        }

        public IActionResult GeneratedPairs()
        {
            var teams = teamQuery.GetTeams().Result;
            resultQuery.RemoveItems();
            var pairs = teams.SelectMany((team1, team1Index) => teams
            .Where((team2, team2Index) => team2Index > team1Index)
            .Select(team2 => (team1.Id, team2.Id))
            );
            foreach (var pair in pairs)
            {
                resultQuery.AddItem(pair.Item1, pair.Item2);
            }

            return RedirectToAction("Index", "Result");
        }

        public IActionResult EditResult()
        {
            editDisabled = false;
            ViewData["editDisabled"] = editDisabled;
            return RedirectToAction("Index");
        }

        public IActionResult SaveResult()
        {
            editDisabled = true;
            ViewData["editDisabled"] = editDisabled;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SaveResult(List<ResultViewModel> model)
        {
            try
            {
                foreach (var item in model)
                {
                    var team1Result = Convert.ToInt32(item.Team1);
                    var team2Result = Convert.ToInt32(item.Team2);
                    if ((team1Result >= 0 && team1Result <= 5) && (team2Result >= 0 && team2Result <= 5))
                    {
                        resultQuery.SaveResult(new Models.Result()
                        {
                            Id = item.Id,
                            Team1Result = team1Result,
                            Team2Result = team2Result,
                            MatchResult = $"{item.Team1}:{item.Team2}"

                        });
                    }
                    else
                    {
                        throw new Exception("Result should be in range [0,5]");

                    }
                }
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            editDisabled = true;
            ViewData["editDisabled"] = editDisabled;
            return RedirectToAction("Index");
        }

        public IActionResult NumberOfPoints()
        {
            var teamIds = teamQuery.GetTeams().Result.Select(x => x.Id).ToList();
            var resultItems = resultQuery.GetResults().Result;
            var model = getPoints(teamIds, resultItems).OrderByDescending(x => x.NumberOfPoints).ThenBy(x => x.TeamName).ToList();

            return View(model);
        }
        private List<PointModel> getPoints(List<int> teamIds, List<ResultViewModel> resultItems)
        {
            List<PointModel> points = new List<PointModel>();
            Dictionary<int, int> teamPoints = new Dictionary<int, int>();
            foreach (var teamId in teamIds)
            {
                teamPoints[teamId] = 0;
            }

            foreach (var result in resultItems)
            {
                int team1Score = Convert.ToInt32(result.Team1);
                int team2Score = Convert.ToInt32(result.Team2);

                if (team1Score > team2Score)
                {
                    teamPoints[result.Team1Id] += 3;
                }
                else if (team1Score < team2Score)
                {
                    teamPoints[result.Team2Id] += 3;
                }
                else
                {
                    teamPoints[result.Team1Id] += 1;
                    teamPoints[result.Team2Id] += 1;
                }
            }

            foreach (var teamId in teamIds)
            {
                points.Add(new PointModel()
                {
                    NumberOfPoints = teamPoints[teamId],
                    TeamName = teamQuery.GetTeamById(teamId).Result.Name
                });
            }
            return points;
        }

    }
}
