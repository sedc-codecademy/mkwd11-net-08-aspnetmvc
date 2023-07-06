using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Services.Abstraction
{
    public interface IMenuItemService
    {
        int GetById(int id);
    }
}
