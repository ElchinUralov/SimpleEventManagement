using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtihon1.Brokers.Exceptions
{
    internal class NotFoundCompanyExceptions : Exception
    {
        public NotFoundCompanyExceptions() : base("Bu companiya topilmadi")
        {

        }
    }
}
