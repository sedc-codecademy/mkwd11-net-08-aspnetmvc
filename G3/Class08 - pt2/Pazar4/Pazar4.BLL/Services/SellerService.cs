using Pazar4.BLL.Hashing;
using Pazar4.BLL.Mapper;
using Pazar4.BLL.Models;
using Pazar4.BLL.Providers;
using Pazar4.BLL.Services.External;
using Pazar4.DAL.Entities;
using Pazar4.DAL.Repository;
using Pazar4.StaticDb.Criterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.BLL.Services
{
    public class SellerService
        : ISellerService
    {
        private readonly IPasswordHasher hasher;
        private readonly IRepository<Seller, SellerCriteria> repository;
        private readonly IEmailSender emailSender;
        private readonly IConfirmationCodeProvider codeProvider;

        public SellerService(
            IPasswordHasher hasher, 
            IRepository<Seller, SellerCriteria> repository, 
            IEmailSender emailSender,
            IConfirmationCodeProvider codeProvider)
        {
            this.hasher = hasher;
            this.repository = repository;
            this.emailSender = emailSender;
            this.codeProvider = codeProvider;
        }
        public async Task<SellerModel> Register(RegisterSellerModel model)
        {
            if(model.Password != model.ConfirmPassword)
            {
                throw new Exception();
            }
            var hashed = hasher.Hash(model.Password);
            Seller seller = new Seller(model.Username, model.Phone, model.Email, hashed)
            {
                ConfirmationCode = codeProvider.GenerateCode()
            };
            repository.Create(seller);

            await emailSender.SendConfirmationEmail(model.Email, seller.ConfirmationCode);
            return seller.ToModel();
        }

        public IEnumerable<SellerModel> GetSellers(int page, int size)
        {
            var skip = page * size;
            var sellers = repository.GetAll(new SellerCriteria // skip, take -> togas nemame genric repository
            {
                Skip = skip,
                Take = size
            });
            return sellers.Select(x => x.ToModel()).ToList();
        }
    }
}
