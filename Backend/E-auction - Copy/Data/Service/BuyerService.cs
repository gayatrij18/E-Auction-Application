using E_auction.Data.Models;
using E_auction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Data.Service
{

    public class BuyerService:IBuyerService
    {
        private AppDBContext _context;

        public BuyerService(AppDBContext context)
        {
            _context = context;
        }
        public void PlaceBid(BuyerDetail buyer)
        {

          
            var _product = _context.ProductDetails.Find(buyer.ProductId);
            

            var _user =  _context.BuyerDetails.FirstOrDefault(n => n.Email == buyer.Email);
            if (_user != null)
            {
                if (_user.ProductId == buyer.ProductId)
                {
                    throw new MultipleBidsFromSameUserException("User has already placed bid on this product");
                }
            }

            if (_product != null)
            {
                
                if(_product.BidEndDate > DateTime.Now)
                {
                    var newBuyer = new BuyerDetail()
                    {
                        FirstName = buyer.FirstName,
                        LastName = buyer.LastName,
                        Address = buyer.Address,
                        City = buyer.City,
                        State = buyer.State,
                        Pincode = buyer.Pincode,
                        Phone = buyer.Phone,
                        Email = buyer.Email,
                        BidAmount = buyer.BidAmount,
                        ProductId = buyer.ProductId


                    };
                    _context.BuyerDetails.Add(newBuyer);
                    _context.SaveChanges();
                }
                else
                {
                    throw new BidEndDateException("Cannot place bid after end date");
                }
                

            }
            else
            {
                throw new ProductNotFoundException("Requested product not found, please select a valid product");
            }


        }

        public void UpdateBid(int buyerId, int newBidAmount)
        {
            var rowToUpdate = _context.BuyerDetails.Find(buyerId);
            var _product = _context.ProductDetails.Find(rowToUpdate.ProductId);
            if(rowToUpdate != null)
            {
                if (DateTime.Now > _product.BidEndDate)
                {
                    throw new BidEndDateException("Bid Amount cannot be modified after bid end date");
                }
                else
                {
                    rowToUpdate.BidAmount = newBidAmount;
                    _context.SaveChanges();
                }
                
            }

        }
    }
}
