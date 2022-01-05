using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface IBooksManager
    {
        string AddBookDetails(BookDetailsModel bookDetailsModel);
        string DeleteBookDetails(int bookId);
    }
}