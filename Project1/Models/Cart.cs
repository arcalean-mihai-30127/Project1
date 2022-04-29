using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Account User { get; set; }
    }
}
