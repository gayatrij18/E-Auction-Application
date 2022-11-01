using E_auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Data.Service
{
    public interface IBuyerService
    {
        public void PlaceBid(BuyerDetail buyer);

        public void UpdateBid(int buyerId, int newBidAmount);
    }
}
