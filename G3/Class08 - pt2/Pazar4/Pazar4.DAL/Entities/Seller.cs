using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.DAL.Entities
{
    public class Seller
        : BaseEntity
    {
        public Seller(string username, string phone, string email, string password)
        {
            Username = username;
            Phone = phone;
            Email = email;
            Password = password;
        }

        public string Username { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool IsConfirmed { get; set; }

        public string? ConfirmationCode { get; set; }

        public ICollection<Listing> Listings { get; set; } = new List<Listing>();
    }
}
