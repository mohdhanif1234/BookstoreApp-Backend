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
    }
}
