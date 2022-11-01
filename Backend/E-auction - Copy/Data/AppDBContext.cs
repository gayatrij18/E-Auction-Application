using E_auction.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<SellerDetail> SellerDetails { get; set; }
        //public DbSet<Product_Seller> Product_Seller_Details { get; set; }

        public DbSet<BuyerDetail> BuyerDetails { get; set; }
        //public DbSet<BidsReceived> BidsReceived { get; set; }
        //public DbSet<Product_Buyer> Product_Buyer_Details { get; set; }


    }
}
