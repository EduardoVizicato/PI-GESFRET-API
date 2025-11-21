using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Application.Models;

namespace TMS.Application.Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(SendEmailRequest request);   
    }
}
