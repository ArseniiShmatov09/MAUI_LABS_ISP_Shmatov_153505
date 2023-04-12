using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUI_LABS.Entities;

namespace MAUI_LABS.Services
{
    public interface IRateService
    {
        IEnumerable<Rate> GetRates(DateTime date, Currency currency);
    }
}
