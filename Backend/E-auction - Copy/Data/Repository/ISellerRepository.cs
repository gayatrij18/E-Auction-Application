using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_auction.Controllers;
using E_auction.Data.Models;

namespace E_auction.Data.Repository
{
    public interface ISellerRepository<ProductDetail>
    {
        public void Authenticate(string email);
        public ProductDetail GetProductDetails(int productID);
        public List<ListedProducts> GetMyProducts(string email, string username);
        public ProductDetail AddProduct(ProductDetail product);
        public void AddProductSeller(SellerDetail seller);
        public List<BidsReceived> GetBids(int productID);

        public void DeleteProduct(int productId);

    }
}
