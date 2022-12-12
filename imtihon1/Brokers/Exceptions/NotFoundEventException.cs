using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtihon1.Brokers.Exceptions
{
    internal class NotFoundEventException : Exception
    {
        public NotFoundEventException() : base("Bu Event topilmadi")
        {

        }
    }
}
