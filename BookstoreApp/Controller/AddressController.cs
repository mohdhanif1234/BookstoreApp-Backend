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
    public class AddressController : ControllerBase
    {
        private readonly IAddressManager addressManager;

        public AddressController(IAddressManager addressManager)
        {
            this.addressManager = addressManager;
        }
        [HttpPost]
        [Route("api/adduseraddress")]
        public IActionResult AddUserAddress([FromBody] AddressModel addressModel)
        {
            try
            {
                string result = this.addressManager.AddUserAddress(addressModel);
                if (result.Equals("User address details added successfully"))
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
        [Route("api/updateuseraddress")]
        public IActionResult UpdateUserAddress([FromBody] AddressModel addressModel)
        {
            try
            {
                string result = this.addressManager.UpdateUserAddress(addressModel);
                if (result.Equals("User address updated successfully"))
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
        [Route("api/getaddressbyuserid")]
        public IActionResult GetAddressByUserId(int userId)
        {
            try
            {
                var result = this.addressManager.GetAddressByUserId(userId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<object>() { Status = true, Message = "Address details retrieved successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "User Id does not Exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/getalladdressdetails")]
        public IActionResult GetAllAddressDetails()
        {
            try
            {
                var result = this.addressManager.GetAllAddressDetails();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<object>() { Status = true, Message = "Address details retrieved successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Address details retrieval is unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
