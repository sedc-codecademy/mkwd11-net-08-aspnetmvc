﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }   
        public string Address { get; set; }   

        public List<Order> Orders { get; set; } 
    }
}
