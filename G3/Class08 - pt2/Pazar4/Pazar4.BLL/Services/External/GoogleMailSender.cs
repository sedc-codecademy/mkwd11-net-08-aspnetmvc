using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.BLL.Services.External
{
    public class GoogleMailSender
        : IEmailSender
    {
        public Task SendConfirmationEmail(string email, string code)
        {
            return Task.FromResult(0);
        }
    }
}
