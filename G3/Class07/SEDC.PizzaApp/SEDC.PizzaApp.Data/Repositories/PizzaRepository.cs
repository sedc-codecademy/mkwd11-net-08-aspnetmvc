using SEDC.PizzaApp.Data.Database;
using SEDC.PizzaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Data.Repositories
{
    public class PizzaRepository
        : IRepository<Pizza>
    {
        public IEnumerable<Pizza> GetAll()
        {
            //var sql = @" SELECT * FROM PIZZA";
            //var sqlConnection = new SqlConnection("");
            //sqlConnection.Open();
            //var command = sqlConnection.CreateCommand();
            //command.CommandText = sql;
            //var reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    //todo return pizza table
            //}
            return PizzaAppDb.Pizzas;
        }

        public void Save(Pizza entity)
        {
            PizzaAppDb.Pizzas.Add(entity);
        }

        public void Delete(Pizza entity)
        {
            PizzaAppDb.Pizzas.Remove(entity);
        }

        public Pizza? GetById(int id)
        {
            return PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Pizza entity)
        {
            // sql
        }
    }
}
