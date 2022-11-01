using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Exceptions
{
    public class DeleteAfterBidEndDateException: Exception
    {
        public DateTime BidEndDate { get; set; }
        public DeleteAfterBidEndDateException()
        {

        }
        public DeleteAfterBidEndDateException(string message): base(message)
        {

        }

        public DeleteAfterBidEndDateException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public DeleteAfterBidEndDateException(string message, DateTime bidEndDate) : this(message)
        {
            BidEndDate = bidEndDate;

        }
    }
}
