using BookstoreModels;
using System.Collections.Generic;

namespace BookstoreRepository.Interface
{
    public interface IBooksRepository
    {
        string connectionString { get; set; }
        string AddBookDetails(BookDetailsModel bookDetailsModel);
        string DeleteBookDetails(int bookId);
        string UpdateBookDetails(BookDetailsModel bookDetailsModel);
        List<BookDetailsModel> GetBookDetailsById(int bookId);
        List<BookDetailsModel> GetAllBookDetails();
    }
}