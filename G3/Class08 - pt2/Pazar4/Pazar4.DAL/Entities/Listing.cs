using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.DAL.Entities
{
    public class Listing
        : BaseEntity
    {
        public Listing(Seller seller, string title)
        {
            ListedBy = seller ?? throw new Exception();
            Title = title ?? throw new Exception();
            Created = DateTime.UtcNow;
        }
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Seller ListedBy { get; set; }
    }
}
