using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.BLL.Models
{
    public class CreateBookModel
    {
        public string Name { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
    }
}
