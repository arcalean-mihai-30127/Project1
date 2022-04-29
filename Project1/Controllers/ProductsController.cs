using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;

namespace Products.Controllers
{
    [Route("api/ProductsVal")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]

        public IEnumerable<Product> ListOfProducts()
        {
            var products = new List<Product>();
            using (var context = new sqltestContext())
            {
                products = context.Products.ToList();
            }
            return products;
        }

        [HttpPost]

        public bool AddProduct(Product product)
        {
            using (var context = new sqltestContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
            return true;

        }

        [HttpDelete]

        public bool DeleteProduct(int productid)
        {

            try
            {
                using (var context = new sqltestContext())
                {
                    var prod = context.Products.Where(e => e.Id == productid).FirstOrDefault();
                    var cart = context.Carts.Where(e => e.ProductId == productid);
                    if (cart != null)
                    {
                        context.Carts.RemoveRange(cart);
                    }
                    context.Products.Remove(prod);                   
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]

        public bool UpdateProduct(Product product)
        {   
            try
            {
                using (var context = new sqltestContext())
                {
                    var prod = context.Products.Where(e => e.Id == product.Id).FirstOrDefault();
                    prod.Name = product.Name;
                    prod.Price = product.Price;
                    prod.Description = product.Description;
                    prod.Image = product.Image;
                    context.Products.Update(prod);
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
