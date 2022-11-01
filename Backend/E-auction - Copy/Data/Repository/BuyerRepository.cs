using E_auction.Data.Models;
using E_auction.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Data.Repository
{
    public class BuyerRepository:IBuyerRepository
    {
        public IBuyerService _buyerService;
        public BuyerRepository(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }
        public void PlaceBid(BuyerDetail buyer)
        {
            _buyerService.PlaceBid(buyer);
        }

        public void UpdateBid(int buyerId, int newBidAmount)
        {
            _buyerService.UpdateBid(buyerId, newBidAmount);

        }
    }
}
