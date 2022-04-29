using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [Route("api/user/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]

        public ActionResult Login(Account user)
        {
            using (var context = new sqltestContext())
            {
                var acc = context.Accounts.Where(e => e.Email == user.Email).FirstOrDefault();
                user.Password = HashPw.Hash(user.Password);
                

                if (acc != null && acc.Password == user.Password)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Successfully logged in",
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Wrong credentials"
                    });
                }
            }
        }
    }
}
