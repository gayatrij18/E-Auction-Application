using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Exceptions
{
    public class ProductNotFoundException:Exception
    {
        public ProductNotFoundException()
        {

        }
        public ProductNotFoundException(string message):base(message)
        {

        }
    }
}
