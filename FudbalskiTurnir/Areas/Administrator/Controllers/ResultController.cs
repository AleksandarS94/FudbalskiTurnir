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
        public IActionResult Index()
        {
            return View();
        }
    }
}
