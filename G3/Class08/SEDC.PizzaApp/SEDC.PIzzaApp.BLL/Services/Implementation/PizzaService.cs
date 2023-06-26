using SEDC.PizzaApp.Data.Models;
using SEDC.PizzaApp.Data.Repositories;
using SEDC.PizzaApp.Web.Mapper;
using SEDC.PizzaApp.BLL.DTOs.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.BLL.Services.Implementation
{
    public class PizzaService
        : IPizzaService
    {
        private readonly IRepository<Pizza> repository;
        private readonly IRepository<Order> orderRepository;

        public PizzaService(IRepository<Pizza> repository, IRepository<Order> orderRepository)
        {
            this.repository = repository;
            this.orderRepository = orderRepository;
        }
        public IEnumerable<PizzaDTO> GetAll()
        {
            IEnumerable<Pizza> pizzas = repository.GetAll();
            return pizzas.Select(x => x.ToDTO());
        }

        public PizzaDTO Create(CreatePizzaDTO create)
        {
            var order = orderRepository.GetById(create.OrderId);
            if(order == null)
            {
                throw new Exception("");
            }

            var pizza = new Pizza(order, create.Name, create.Price)
            {
                IsOnPromotion = create.IsOnPromotion
            };

            repository.Save(pizza);
            return pizza.ToDTO();
        }

        public void Delete(int id)
        {
            var pizza = repository.GetById(id);
            if(pizza == null)
            {
                throw new Exception();
            }

            // TODO check user priviliges
            repository.Delete(pizza);
        }



        public PizzaDTO GetById(int id)
        {
            Pizza? pizza = repository.GetById(id);

            if(pizza == null)
            {
                throw new Exception("Pizza not found");
            }
            return pizza.ToDTO();
        }

        public PizzaDTO Update(PizzaDTO pizzaDTO)
        {
            Pizza? pizza = repository.GetById(pizzaDTO.Id);

            if(pizza == null)
            {
                throw new Exception("");
            }
            pizza.Price = pizzaDTO.Price;
            pizza.Name = pizzaDTO.Name;
            pizza.IsOnPromotion = pizzaDTO.IsOnPromotion;

            repository.Update(pizza);
            return pizza.ToDTO();
        }
    }
}
