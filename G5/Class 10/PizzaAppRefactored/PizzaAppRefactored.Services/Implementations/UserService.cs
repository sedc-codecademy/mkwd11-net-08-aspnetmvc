﻿using PizzaAppRefactored.DataAccess;
using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.Mappers;
using PizzaAppRefactored.Services.Interfaces;
using PizzaAppRefactored.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserOptionViewModel> GetAllUsersForDropDown()
        {
            List<User> users = _userRepository.GetAll();

            List<UserOptionViewModel> userOptionViewModels = users.Select(x => UserMapper.ToUserOptionViewModel(x)).ToList();
            return userOptionViewModels;
        }
    }
}
