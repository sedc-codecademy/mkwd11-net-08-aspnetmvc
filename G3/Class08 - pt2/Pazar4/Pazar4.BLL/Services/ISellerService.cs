using Pazar4.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.BLL.Services
{
    public interface ISellerService
    {
        Task<SellerModel> Register(RegisterSellerModel model);

        IEnumerable<SellerModel> GetSellers(int page, int size);
    }
}
