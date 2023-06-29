using SEDC.PizzaApp.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Services
{
    public class A1SmsService : ISmsService
    {
        public string Send(string phoneNumber, string message)
        {
            return $"Using A1 sending sms to {phoneNumber}: {message}";
        }
    }
}
