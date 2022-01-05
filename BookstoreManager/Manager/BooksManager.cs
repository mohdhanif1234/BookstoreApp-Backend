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
    }
}
