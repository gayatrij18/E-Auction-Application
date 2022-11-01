using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Exceptions
{
    public class MultipleBidsFromSameUserException:Exception
    {
        public MultipleBidsFromSameUserException()
        {

        }
        public MultipleBidsFromSameUserException(string message): base(message)
        {

        }
    }
}
