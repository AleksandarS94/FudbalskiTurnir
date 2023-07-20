using FudbalskiTurnir.Areas.Administrator.Queries;
using FudbalskiTurnir.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Areas.Administrator.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly PlayerQuery query;
        private readonly TeamQuery teamQuery;
        public PlayerController(PlayerQuery query, TeamQuery teamQuery)
        {
            this.query = query;
            this.teamQuery = teamQuery;
        }
        public async Task<IActionResult> Index()
        {
            var players = await query.GetPlayers();
            return View(players);
        }

        public async Task<IActionResult> AddPlayer()
        {
            ViewData["PlayerTeams"] = await teamQuery.GetTeams();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(Player model)
        {
            if (ModelState.IsValid)
            {
                await query.AddItem(model);
                return RedirectToAction("Index", "Player");
            }
            else
            {
                ModelState.AddModelError("", "Wrong input fields.");
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await query.DeleteItem(id);

            return RedirectToAction("Index", "Player");
        }
        public async Task<IActionResult> EditPlayer(int id)
        {
            var player = await query.GetPlayerById(id);
            ViewData["PlayerTeams"] = await teamQuery.GetTeams();
            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlayer(Player model)
        {
            if (ModelState.IsValid)
            {
                await query.UpdateItem(model);
                return RedirectToAction("Index", "Player");
            }
            else
            {
                ModelState.AddModelError("", "Name should exist.");
            }
            return View();


        }

    }
}
