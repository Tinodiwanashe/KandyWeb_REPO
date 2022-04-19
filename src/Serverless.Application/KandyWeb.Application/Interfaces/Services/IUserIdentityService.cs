using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Application.Interfaces.Services
{
    public interface IUserIdentityService
    {
        string UserId { get; }

        bool IsAuthenticated { get; }

        List<KeyValuePair<string, string>> Claims { get; set; }
    }
}
