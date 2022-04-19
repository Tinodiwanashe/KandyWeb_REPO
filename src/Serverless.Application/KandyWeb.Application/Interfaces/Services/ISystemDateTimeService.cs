using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Application.Interfaces.Services
{
    public interface ISystemDateTimeService
    {
        public DateTime UTCNow { get; }
        public int CurrentYear { get; }
        public string GetPassedTime(DateTime currentDate, DateTime originalDate);
    }
}
