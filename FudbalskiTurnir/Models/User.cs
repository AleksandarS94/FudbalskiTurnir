using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Models
{
    [Table("Users")]
    public class User
    {

        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimum 3 characters")]
        public string Password { get; set; }



    }
}
