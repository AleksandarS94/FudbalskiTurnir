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
        private readonly FudbalskiTurnirContext context;
        public Login(FudbalskiTurnirContext context)
        {
            this.context = context;
        }
        public User getLoginUser(User user)
        {
            var db = context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            return db;
        }
    }
}
