
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_auction.Data.Repository;
using E_auction.Data.Service;
using E_auction.Data.Models;
using E_auction.Exceptions;
using E_auction.Data;
using Microsoft.AspNetCore.Authorization;

namespace E_auction.Controllers
{

    [ApiVersion("1.0")]
    [Route("e-auction/api/{v:apiVersion}/[controller]")]
    /*[Route("e-auction/api/{id:int:min(1)}/[controller]")]*/
    [ApiController]
    public class SellerController : ControllerBase
    {
       
        public ISellerRepository<ProductDetail> _sellerRepository;
        public SellerController(ISellerRepository<ProductDetail> sellerRepository)
        {

            _sellerRepository = sellerRepository;
        }
        [HttpPost("authenticate-seller")]
        public IActionResult Authenticate(string email)
        {
            try
            {
                _sellerRepository.Authenticate(email);
                return Ok();
            }
            catch(UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("get-product-details-by-Id")]
        public IActionResult GetProductDetails(int productID)
        {

            ProductDetail productDetails = _sellerRepository.GetProductDetails(productID);
            return Ok(productDetails);

        }

        [HttpGet("get-bids")]
        public IActionResult GetBids(int productID)
        {

            List<BidsReceived> allBids = _sellerRepository.GetBids(productID);
            return Ok(allBids);
        }
        [Authorize]
        [HttpGet("get-my-products")]
        public IActionResult GetMyProducts(string email)
        {
            string username = User.Claims.First(c => c.Type == "Username").Value;
            var productDetails = _sellerRepository.GetMyProducts(email, username);
            return Ok(productDetails);

        }

        [HttpPost("add-product")]
        public IActionResult AddProduct(ProductDetail product)
        {
            try
            {
                ProductDetail newProduct = _sellerRepository.AddProduct(product);
                return Created(nameof(AddProduct), newProduct);
            }
            catch (BidEndDateException ex)
            {
                return BadRequest($"{ex.Message}, Bid end date:{ex.BidEndDate}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
           

            //return Ok(productDetails);

        }

        [HttpPost("add-product-with-seller")]
        public IActionResult AddProductSeller(SellerDetail seller)
        {
            try
            {
                _sellerRepository.AddProductSeller(seller);
                return Created(nameof(AddProductSeller), seller);
            }
             catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



            //return Ok(productDetails);

        }


        [HttpDelete("delete-product/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                _sellerRepository.DeleteProduct(productId);
                return Ok("Product Deleted successfully");
            }
            catch(DeleteAfterBidEndDateException ex)
            {
                return BadRequest($"{ex.Message}, Bid end date:{ex.BidEndDate}");
            }
            catch(DeleteAfterBidPlacedException ex)
            {
                return BadRequest($"{ex.Message}");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }


        
}
