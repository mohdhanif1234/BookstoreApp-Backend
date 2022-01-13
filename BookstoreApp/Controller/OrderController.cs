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
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager orderManager;

        public OrderController(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
        }
        [HttpPost]
        [Route("api/addorder")]
        public IActionResult AddOrder([FromBody] OrderModel orderModel)
        {
            try
            {
                string result = this.orderManager.AddOrder(orderModel);
                if (result.Equals("Ordered successfully"))
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
        [Route("api/getorders")]
        public IActionResult RetrieveOrderDetails(int userId)
        {
            try
            {
                var result = this.orderManager.RetrieveOrderDetails(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Retrieval unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                //this.logger.LogWarning("Exception caught while adding new user" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
