using Microsoft.AspNetCore.Identity;

namespace FudbalskiTurnir.Infrastruktura
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }
    }
}