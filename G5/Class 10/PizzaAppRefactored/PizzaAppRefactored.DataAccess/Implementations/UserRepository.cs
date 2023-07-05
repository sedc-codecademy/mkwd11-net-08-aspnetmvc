﻿using PizzaAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.DataAccess.Implementations
{
    public class UserRepository : IRepository<User>
    {
        public void DeleteById(int id)
        {
           User user = StaticDb.Users.FirstOrDefault(u => u.Id == id);
            
            if(user == null) {
                throw new Exception($"The user with id {id} does not exist");
            }

           StaticDb.Users.Remove(user); 
        }

        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            var user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception($"The user with id {id} does not exist");
            }
            return user;
        }

        public int Insert(User entity)
        {
            entity.Id = StaticDb.Users.Count() + 1;
            StaticDb.Users.Add(entity);
            return entity.Id;
        }

        public void Update(User entity)
        {
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (user == null)
            {
                throw new Exception($"User with id {entity.Id} was not found!");
            }

            int index = StaticDb.Users.FindIndex(x => x.Id == entity.Id);

            StaticDb.Users[index] = entity;
        }
    }
}
