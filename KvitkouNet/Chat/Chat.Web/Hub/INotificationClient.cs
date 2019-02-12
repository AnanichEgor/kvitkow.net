using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Web.Hub
{
    public interface INotificationClient
    {
        Task GetAlert(string message);
    }
}
