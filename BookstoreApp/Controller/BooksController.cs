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
    public class BooksController : ControllerBase
    {
        private readonly IBooksManager manager;

        public BooksController(IBooksManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/addbookdetails")]
        public IActionResult AddBookDetails([FromBody] BookDetailsModel bookDetailsModel)
        {
            try
            {
                string result = this.manager.AddBookDetails(bookDetailsModel);
                if (result.Equals("Book details added successfully"))
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
        [Route("api/deletebookdetails")]
        public IActionResult DeleteBookDetails(int bookId)
        {
            try
            {
                string result = this.manager.DeleteBookDetails(bookId);
                if (result.Equals("Book details deleted successfully"))
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
        [Route("api/updatebookdetails")]
        public IActionResult UpdateBookDetails([FromBody] BookDetailsModel bookDetailsModel)
        {
            try
            {
                string result = this.manager.UpdateBookDetails(bookDetailsModel);
                if (result.Equals("Book details updated successfully"))
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
        [Route("api/getbookdetailsbyid")]
        public IActionResult GetBookDetailsById(int bookId)
        {
            try
            {
                List<BookDetailsModel> result = this.manager.GetBookDetailsById(bookId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Book does not exist. Kindly a new book with details to retrieve." });
                }
                else
                {
                    return this.Ok(new ResponseModel<List<BookDetailsModel>>() { Status = true, Message = "Book details retrieved successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
    }
}
