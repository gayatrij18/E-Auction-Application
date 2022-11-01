using E_auction.Data.Models;
using E_auction.Data.Repository;
using E_auction.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_auction.Controllers
{
    /*[Route("api/[controller]")]*/
    [ApiVersion("1.0")]
    [Route("e-auction/api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        public IBuyerRepository _buyerRepository;
        public BuyerController(IBuyerRepository buyerRepository)
        {

            _buyerRepository = buyerRepository;
        }

        [HttpPost("place-bid")]
        public IActionResult PlaceBid(BuyerDetail buyer)
        {
            try
            {
                _buyerRepository.PlaceBid(buyer);
                return Created(nameof(PlaceBid), buyer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //return Ok(productDetails);

        }

        [HttpPut("update-bid")]
        public IActionResult UpdateBid(int buyerId, int newBidAmount)
        {
            try
            {
                _buyerRepository.UpdateBid(buyerId, newBidAmount);
                return Ok();
            }
            catch(BidEndDateException ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }
    }
}
