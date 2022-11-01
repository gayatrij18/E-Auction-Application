using E_auction.Data.Models;
using E_auction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Data.Service
{
    public class SellerService:ISellerService<ProductDetail>
    {
        public AppDBContext _context;
        public SellerService(AppDBContext context)
        {
            _context = context;


        }

        public void Authenticate(string email)
        {
            var _user = _context.SellerDetails.FirstOrDefault(s => s.Email == email);
            if(_user == null)
            {
                throw new UserNotFoundException("Please enter valid credentials");

            }
        }
        public ProductDetail GetProductDetails(int productID)
        {
            ProductDetail details = _context.ProductDetails.FirstOrDefault(n => n.Id == productID);
            return details;
        }

        public List<ListedProducts> GetMyProducts(string email, string username)
        {
            var seller = _context.SellerDetails.FirstOrDefault(n => n.Email == username);
            var listedProds =  _context.ProductDetails.Where(p=>p.SellerIDFK ==seller.SellerID).ToList();


            List<ListedProducts> listOfProducts = new List<ListedProducts>();
            ListedProducts myListedProducts= new ListedProducts();
            foreach (var prod in listedProds)
            {
                myListedProducts =  new ListedProducts()
                {
                    Id = prod.Id,
                    ProductName = prod.ProductName

                };
                listOfProducts.Add(myListedProducts);

            }
            
            return listOfProducts;

        }


        public List<BidsReceived> GetBids(int productID)
        {

            /* return _context.ProductDetails.Where(n => n.Id == productID)
                 .Select(n => new ProductDetail()
                 {
                      = n.Buyers[0].BidAmount
                 }).ToList();*/
            //return b.buyer.BidAmount;

            var allBids = (from p in _context.ProductDetails
                          join b in _context.BuyerDetails
                          on p.Id equals b.ProductId
                          where p.Id == productID
                          select new BidsReceived()
                          {
                              Id = p.Id,
                              ProductName = p.ProductName,
                              ShortDescription = p.ShortDescription,
                              DetailedDescription = p.DetailedDescription,
                              Category = p.Category,
                              StartingPrice = p.StartingPrice,
                              BidEndDate = p.BidEndDate,
                              FirstName = b.FirstName,
                              LastName = b.LastName,
                              BidAmount = b.BidAmount
                          }).ToList();

            return allBids;

        }

        public ProductDetail AddProduct(ProductDetail product)
        {
           
            var newProduct = new ProductDetail()
            {
                ProductName = product.ProductName,
                ShortDescription = product.ShortDescription,
                DetailedDescription = product.DetailedDescription,
                Category = product.Category,
                StartingPrice = product.StartingPrice,
                BidEndDate = product.BidEndDate,
                SellerIDFK = product.SellerIDFK

            };

            _context.ProductDetails.Add(newProduct);
            _context.SaveChanges();
            
            return newProduct;

        }

        public void AddProductSeller(SellerDetail seller)
        {
            var newProductSeller = new SellerDetail()
            {
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Address = seller.Address,
                City = seller.City,
                State = seller.State,
                Pin = seller.Pin,
                Phone = seller.Phone,
                Email = seller.Email,
                ProductDetails = seller.ProductDetails
               


            };
            
            _context.SellerDetails.Add(newProductSeller);
            
            _context.SaveChanges();

            
        }

        public void DeleteProduct(int productId)
        {
            var _product = _context.ProductDetails.FirstOrDefault(n => n.Id == productId);
            if(_product!=null)
            {
                if (!IsBidEndDateCrossed(_product.BidEndDate))
                {
                    if(!_product.BidsPlaced)
                    {
                        var deletedProduct = _context.ProductDetails.Remove(_product);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new DeleteAfterBidPlacedException("Cannot delete product once bids are placed");
                    }
                    
                }
                else
                {
                    throw new DeleteAfterBidEndDateException("Product deletion after the bid end date cannot be allowed", _product.BidEndDate);
                }
                
            }
           
        }

        public bool IsBidEndDateCrossed(DateTime endDate)
        {
            if (DateTime.Now > endDate)
                return true;
            else
                return false;
        }


    }
}
