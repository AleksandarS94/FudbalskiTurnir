using FudbalskiTurnir.Infrastruktura;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class PagesController : Controller
    {
        private readonly FudbalskiTurnirContext context;

        public PagesController(FudbalskiTurnirContext context)
        {
            this.context = context;
        }
        public string Index()
        {
            return "test";
        }
    }
}
