using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.Models
{
    public partial class Account
    {
        public Account()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PhoneNumber { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
