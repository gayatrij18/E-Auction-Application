using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Exceptions
{
    public class BidEndDateException:Exception
    {
        public DateTime BidEndDate { get; set; }
        public BidEndDateException()
        {

        }

        public BidEndDateException(string message):base(message)
        {

        }

        public BidEndDateException(string message, Exception innerException):base(message, innerException)
        {

        }

        public BidEndDateException(string message, DateTime bidEndDate):this(message)
        {
            BidEndDate = bidEndDate;

        }
    }
}
