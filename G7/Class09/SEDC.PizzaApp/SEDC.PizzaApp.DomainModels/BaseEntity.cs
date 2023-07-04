using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DomainModels
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public BaseEntity()
        {
            
        }

        public BaseEntity(int id)
        {
            Id = id;
        }
    }
}
