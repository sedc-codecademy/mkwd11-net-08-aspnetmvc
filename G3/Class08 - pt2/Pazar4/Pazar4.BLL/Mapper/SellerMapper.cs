using Pazar4.BLL.Models;
using Pazar4.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.BLL.Mapper
{
    public static class SellerMapper
    {
        public static SellerModel ToModel(this Seller seller)
        {
            return new SellerModel
            {
                Id = seller.Id,
                Email = seller.Email,
                Phone = seller.Phone,
                Username = seller.Username
            };
        }
    }
}
