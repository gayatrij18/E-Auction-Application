using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Data.Models
{
    public class SellerDetail
    {

        [Key]
        public int SellerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string Pin { get; set; }
        public string Phone { get; set; }
            
        public string Email { get; set; }

        public List<ProductDetail> ProductDetails { get; set; }


    }
}
