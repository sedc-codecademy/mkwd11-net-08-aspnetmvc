﻿using Domain.Models;
using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp.Models.Domain
{
    public class Order : BaseEntity
    {
        public int PizzaId { get; set; }
        public int UserId { get; set; }
        public Pizza Pizza { get; set; }
        public User User { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool Delivered { get; set; }
    }
}
