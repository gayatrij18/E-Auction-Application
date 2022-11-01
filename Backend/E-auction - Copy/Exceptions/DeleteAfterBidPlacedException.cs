using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Exceptions
{
    public class DeleteAfterBidPlacedException:Exception
    {
        public DeleteAfterBidPlacedException()
        {

        }
        public DeleteAfterBidPlacedException(string message):base(message)
        {

        }
    }
}
