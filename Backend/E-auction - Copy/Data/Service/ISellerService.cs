using E_auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Data.Service
{
    public interface ISellerService<ProductDetail>
    {
        public void Authenticate(string email);
        public ProductDetail GetProductDetails(int productID);
        public List<ListedProducts> GetMyProducts(string email, string username);
        public ProductDetail AddProduct(ProductDetail product);
        public void AddProductSeller(SellerDetail seller);

        public void DeleteProduct(int productId);
        public List<BidsReceived> GetBids(int productID);
    }
}
