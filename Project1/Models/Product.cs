using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
