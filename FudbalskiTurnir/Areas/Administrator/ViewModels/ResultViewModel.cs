using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Areas.Administrator.ViewModels
{
    public class ResultViewModel
    {
        public int Id { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public string MatchPair { get; set; }
        public string MatchResult { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
    }
}
