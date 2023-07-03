using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.BLL.Hashing
{
    public interface IPasswordHasher
    {
        string Hash(string password);
    }
}
