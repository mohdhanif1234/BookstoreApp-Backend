using BookstoreManager.Interface;
using BookstoreModels;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApp.Controller
{
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistManager wishlistManager;
        public WishlistController(IWishlistManager wishlistManager)
        {
            this.wishlistManager = wishlistManager;
        }
        [HttpPost]
        [Route("api/addtowishlist")]
        public IActionResult AddToWishlist([FromBody] WishlistModel wishlistModel)
        {
            try
            {
                string result = this.wishlistManager.AddToWishlist(wishlistModel);
                if (result.Equals("Book added to wishlist successfully"))
                {

                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("api/deletefromwishlist")]
        public IActionResult DeleteFromWishlist(int wishlistId)
        {
            try
            {
                string result = this.wishlistManager.DeleteFromWishlist(wishlistId);
                if (result.Equals("Book deleted from wishlist successfully"))
                {

                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/getwishlistdetailsbyuserid")]
        public IActionResult GetWishlistDetailsByUserId(int userId) 
        {
            try
            {
                var result = this.wishlistManager.GetWishlistDetailsByUserId(userId);
                if (result != null)
                {

                    return this.Ok(new { Status = true, Message = "Wishlist details retrieved successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Wishlist details retrieval is unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
