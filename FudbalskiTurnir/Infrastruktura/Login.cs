using FudbalskiTurnir.Infrastruktura;
using FudbalskiTurnir.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Infrastruktura
{
    public class Login
    {
        FudbalskiTurnirContext dbContext = new FudbalskiTurnirContext();
        public async Task<User> getLoginUser(User user)
        {
            var db = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
            return db;
        }
    }
}
