﻿namespace SEDC.PizzaApp.BLL.DTOs.Pizzas
{
    public class PizzaDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsOnPromotion { get; set; }
    }
}
