using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.BAL.Helpers
{
    public class CarExceptoin : Exception
    {
        public CarExceptoin(string message)
       : base(message) { }
    }
}
