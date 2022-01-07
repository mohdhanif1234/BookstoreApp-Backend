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
    public class CartController : ControllerBase
    {
        private readonly ICartManager cartManager;

        public CartController(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }

        [HttpPost]
        [Route("api/addtocart")]
        public IActionResult AddToCart([FromBody] CartModel cartModel)
        {
            try
            {
                string result = this.cartManager.AddToCart(cartModel);
                if (result.Equals("The book is added to the cart successfully"))
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
        [HttpPut]
        [Route("api/updatebookquantity")]
        public IActionResult UpdateBookQuantity(int cartId, int qtyToOrder)
        {
            try
            {
                string result = this.cartManager.UpdateBookQuantity(cartId, qtyToOrder);
                if (result.Equals("Book quantity updated successfully"))
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
        [Route("api/deletecart")]
        public IActionResult DeleteCart(int cartId)
        {
            try
            {
                string result = this.cartManager.DeleteCart(cartId);
                if (result.Equals("Cart details deleted successfully"))
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
        [Route("api/getcartdetails")]
        public IActionResult GetCartDetails(int userId)
        {
            try
            {
                var result = this.cartManager.GetCartDetails(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Cart details retrieved successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Cart details retrieval is unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
