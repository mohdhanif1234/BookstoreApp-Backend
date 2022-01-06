using BookstoreManager.Interface;
using BookstoreModels;
using BookstoreRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManager.Manager
{
    public class BooksManager : IBooksManager
    {
        private readonly IBooksRepository repository;
        public BooksManager(IBooksRepository repository)
        {
            this.repository = repository;
        }
        public string AddBookDetails(BookDetailsModel bookDetailsModel)
        {
            try
            {
                return this.repository.AddBookDetails(bookDetailsModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteBookDetails(int bookId)
        {
            try
            {
                return this.repository.DeleteBookDetails(bookId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateBookDetails(BookDetailsModel bookDetailsModel)
        {
            try
            {
                return this.repository.UpdateBookDetails(bookDetailsModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BookDetailsModel> GetBookDetailsById(int bookId)
        {
            try
            {
                return this.repository.GetBookDetailsById(bookId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BookDetailsModel> GetAllBookDetails()
        {
            try
            {
                return this.repository.GetAllBookDetails();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
