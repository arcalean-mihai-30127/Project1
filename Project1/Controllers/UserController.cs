using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost("getId")]

        public int GetId(Account user)
        {
            using (var context = new sqltestContext())
            {
                var acc = context.Accounts.Where(e => e.Email == user.Email).FirstOrDefault();
                return acc.Id;
            }
        }

        [HttpPost("getRole")]

        public bool GetRole(Account user)
        {
            using (var context = new sqltestContext())
            {
                var acc = context.Accounts.Where(e => e.Email == user.Email).FirstOrDefault();


                if (acc != null && acc.Role == "admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
