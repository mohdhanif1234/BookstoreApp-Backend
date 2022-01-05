using BookstoreModels;

namespace BookstoreRepository.Interface
{
    public interface IBooksRepository
    {
        string connectionString { get; set; }
        string AddBookDetails(BookDetailsModel bookDetailsModel);
    }
}