using FudbalskiTurnir.Areas.Administrator.Queries;
using FudbalskiTurnir.Infrastruktura;
using FudbalskiTurnir.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Areas.Administrator.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly TeamQuery query;
        public TeamController(TeamQuery query)
        {
            this.query = query;
        }
        public async Task<IActionResult> Index()
        {
            var teams = await query.GetTeams();
            return View(teams);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await query.DeleteItem(id);

            return RedirectToAction("Index", "Team");
        }

        public async Task<IActionResult> AddTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(Team model)
        {
            if (ModelState.IsValid)
            {
                await query.AddItem(model);
                return RedirectToAction("Index", "Team");
            }
            else
            {
                ModelState.AddModelError("", "Name should exist.");
            }


            return View();
        }

        public async Task<IActionResult> EditTeam(int id)
        {
            var team = await query.GetTeamById(id);
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeam(Team model)
        {
            if (ModelState.IsValid)
            {
                await query.UpdateItem(model);
                return RedirectToAction("Index", "Team");
            }
            else
            {
                ModelState.AddModelError("", "Name should exist.");
            }
            return View();

            
        }
    }
}
