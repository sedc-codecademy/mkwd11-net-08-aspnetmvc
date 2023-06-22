using SEDC.PizzaApp.BLL.DTOs.Users;
using SEDC.PizzaApp.Data.Models;
using SEDC.PizzaApp.Data.Repositories;
using SEDC.PizzaApp.Web.Mapper;
using SEDC.UserApp.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.BLL.Services.Implementation
{
    public class UserService
        : IUserService
    {
        private readonly IRepository<User> repository;

        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }
        public UserDTO Create(CreateUserDTO create)
        {
            //if (string.IsNullOrEmpty(create.FirstName))
            //{
            //    throw new Exception( "First name can not be empty");
            //}
            //if (string.IsNullOrEmpty(create.LastName))
            //{
            //    ViewBag.Error = "Last name can not be empty";
            //    return View();
            //}
            //if (string.IsNullOrEmpty(create.Phone))
            //{
            //    ViewBag.Error = "Phone can not be empty";
            //    return View();
            //}
            var user = new User(create.FirstName, create.LastName, create.Phone);
            repository.Save(user);
            return user.ToDTO();
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO Update(UserDTO UserDTO)
        {
            throw new NotImplementedException();
        }
    }
}
