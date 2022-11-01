using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Data.Models
{
    public class ProductDetail
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string Category { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; }

        public bool BidsPlaced { get; set; } = false;

        public List<BuyerDetail> Buyers { get; set; }
        //chsnge
        public int? SellerIDFK { get; set; }

        [ForeignKey("SellerIDFK")]
        public SellerDetail SellerDetail { get; set; }










    }
}
    