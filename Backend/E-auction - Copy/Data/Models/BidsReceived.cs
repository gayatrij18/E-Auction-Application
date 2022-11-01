using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Data.Models
{
    public class BidsReceived
    {
        public int Id { get; set; }
        
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string Category { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BidAmount { get; set; }



    }
}
