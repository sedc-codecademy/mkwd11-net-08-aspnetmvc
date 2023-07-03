using SEDC.PizzaApp.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Services
{
    public class TMobileSmsService : ISmsService
    {
        public string Send(string phoneNumber, string message)
        {
            return $"Using T-Mobile sending sms to {phoneNumber}: {message}";
        }
    }
}
