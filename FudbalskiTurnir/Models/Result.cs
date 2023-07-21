using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Teams")]
        [Requierd]
        public int FirstTeamId { get; set; }

        [ForeignKey("Teams")]
        [Requierd]
        public int SecondTeamId { get; set; }

        [RegularExpression(@"\d[0-5]:[0-5]\d")]
        [Requierd]
        public string MatchResult { get; set; }

        [RegularExpression(@"\d[0-5]\d")]
        [Requierd]
        public int Team1Result { get; set; }
        [RegularExpression(@"\d[0-5]\d")]
        [Requierd]
        public int Team2Result { get; set; }
    }
}
