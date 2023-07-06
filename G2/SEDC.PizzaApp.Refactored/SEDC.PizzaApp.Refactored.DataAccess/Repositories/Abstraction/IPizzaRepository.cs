using SEDC.PizzaApp.Refactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.DataAccess.Repositories.Abstraction
{
    public interface IPizzaRepository : IRepository<Pizza>
    {
        Pizza GetPizzaOnPromotion();
    }
}
