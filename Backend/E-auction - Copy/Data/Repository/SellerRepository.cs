using E_auction.Data.Models;
using E_auction.Data.Service;
using E_auction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Data.Repository
{
    public class SellerRepository:ISellerRepository<ProductDetail>
    {
        public ISellerService<ProductDetail> _sellerService;

        public SellerRepository(ISellerService<ProductDetail> sellerService)
        {
            _sellerService = sellerService;
        }

        public void Authenticate(string email)
        {
            _sellerService.Authenticate(email);
        }
        public ProductDetail GetProductDetails(int productID)
        {

            ProductDetail productDetails = _sellerService.GetProductDetails(productID);
            return productDetails;

        }
        public List<BidsReceived> GetBids(int productID)
        {
            return _sellerService.GetBids(productID);
        }
        public List<ListedProducts> GetMyProducts(string email, string username)
        {
            return _sellerService.GetMyProducts(email, username);

        }

        public ProductDetail AddProduct(ProductDetail product)
        {
            if (!IsFutureDate(product.BidEndDate))
            {
                throw new BidEndDateException("Entered date not a future date");
            }
            else
            {
                ProductDetail newProduct = _sellerService.AddProduct(product);
                return newProduct;
            }
            

        }

        public void AddProductSeller(SellerDetail seller)
        {
            if (!IsFutureDate(seller.ProductDetails[0].BidEndDate))
            {
                throw new BidEndDateException("Entered date not a future date");
            }
            else
            {
                _sellerService.AddProductSeller(seller);

            }
           


        }

        public void DeleteProduct(int productId)
        {
            _sellerService.DeleteProduct(productId);
        }

        public bool IsFutureDate(DateTime endDate)
        {
            if (DateTime.Now <= endDate)
                return true;
            else
                return false;
        }

       
    }
}
