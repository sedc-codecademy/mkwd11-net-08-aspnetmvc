using SEDC.PIzzaApp.BLL.DTOs.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PIzzaApp.BLL.Services
{
    public interface IPizzaService
    {
        public IEnumerable<PizzaDTO> GetAll();

        public PizzaDTO GetById(int id);

        public PizzaDTO Update(PizzaDTO PizzaDTO);

        public PizzaDTO Create(CreatePizzaDTO create);

        public void Delete(int id);
    }
}
