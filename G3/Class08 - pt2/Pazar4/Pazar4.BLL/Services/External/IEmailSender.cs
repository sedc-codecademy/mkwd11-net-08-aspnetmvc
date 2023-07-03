using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.BLL.Services.External
{
    public interface IEmailSender
    {
        Task SendConfirmationEmail(string email, string code);
    }
}
