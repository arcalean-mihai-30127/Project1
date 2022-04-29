using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [Route("api/user/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]

        public ActionResult Register(Account user)
        {

            using (var context = new sqltestContext())
            {
               var acc = context.Accounts.Where(e => e.Email == user.Email).FirstOrDefault();

                if (acc == null)
                {
                    user.Password = HashPw.Hash(user.Password);
                    context.Accounts.Add(user);
                    context.SaveChanges();
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Successfully registered",
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Email already registered"
                    }); ;
                }
            }
        }
    }
}
