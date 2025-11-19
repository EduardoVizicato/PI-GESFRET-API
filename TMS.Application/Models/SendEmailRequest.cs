using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Application.Models
{
    public record SendEmailRequest(string Recipient, string Subject, string Body);

}
