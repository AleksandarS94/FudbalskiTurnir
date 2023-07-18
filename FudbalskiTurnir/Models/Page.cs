using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Models
{
    public class Page
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Sorting { get; set; }
    }
}
