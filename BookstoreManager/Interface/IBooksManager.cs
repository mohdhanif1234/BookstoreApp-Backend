using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface IBooksManager
    {
        string AddBookDetails(BookDetailsModel bookDetailsModel);
    }
}