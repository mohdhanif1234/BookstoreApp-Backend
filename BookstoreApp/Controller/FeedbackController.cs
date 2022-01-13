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
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackManager feedbackManager;

        public FeedbackController(IFeedbackManager feedbackManager)
        {
            this.feedbackManager = feedbackManager;
        }
        [HttpPost]
        [Route("api/addfeedback")]
        public IActionResult AddFeedback([FromBody] FeedbackModel feedback)
        {
            try
            {
                string result = this.feedbackManager.AddFeedback(feedback);
                if (result.Equals("Feedback added successfully"))
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
