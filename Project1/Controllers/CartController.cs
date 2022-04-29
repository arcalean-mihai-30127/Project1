using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;

namespace Project1.Controllers
{
    [Route("api/CartItems")]
    [ApiController]
    public class CartController : ControllerBase
    {

        [HttpPost("getItems")]

        public IEnumerable<CartItems> ListOfProducts(Account userEmail)
        {            

            var products = new List<CartItems>();

            using (var context = new sqltestContext())
            {
                var user = context.Accounts.Where(e => e.Email == userEmail.Email).FirstOrDefault();
                
                var cartitems = context.Carts.Where(e => e.UserId == user.Id);

                var asd = from a in cartitems
                          from b in context.Products
                          where a.ProductId == b.Id
                          select new CartItems
                          {
                              Id = b.Id,
                              Name = b.Name,
                              Image = b.Image,
                              Quantity = a.Quantity,
                              Price = b.Price,
                          };
                products = asd.ToList();
            }
            return products;
        }

        [HttpPost("addItems")]

        public bool AddToCart(ProdUser prodUser)
        {

              using (var context = new sqltestContext())
              {
                 var user = context.Accounts.Where(e => e.Email == prodUser.UserEmail).FirstOrDefault();
            
                 var cartItem = new Cart();



                 cartItem.ProductId = prodUser.ProdId;
                 cartItem.UserId = user.Id;
                 cartItem.Quantity = 1;
                 cartItem.CartId = 1;

                 context.Carts.Add(cartItem);
                 context.SaveChanges();
            }
            return true;

        }

        [HttpDelete]

        public bool DeleteProduct(int productid,int userid)
        {
            try
            {
                using (var context = new sqltestContext())
                {
                    var cartItem = context.Carts.Where(e => e.ProductId == productid).Where(e=> e.UserId == userid).FirstOrDefault();
                    context.Carts.Remove(cartItem);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
