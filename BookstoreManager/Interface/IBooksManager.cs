using BookstoreModels;
using System.Collections.Generic;

namespace BookstoreManager.Interface
{
    public interface IBooksManager
    {
        string AddBookDetails(BookDetailsModel bookDetailsModel);
        string DeleteBookDetails(int bookId);
        string UpdateBookDetails(BookDetailsModel bookDetailsModel);
        List<BookDetailsModel> GetBookDetailsById(int bookId);
        List<BookDetailsModel> GetAllBookDetails();
    }
}