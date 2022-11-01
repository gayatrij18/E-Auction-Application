using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_auction.Data.Models
{
    public class BuyerDetail
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
       // public int ProductID { get; set; }

        public decimal BidAmount { get; set; }

        [JsonIgnore]
        public ProductDetail product { get; set; }
        public int ProductId { get; set; }
    }
}
