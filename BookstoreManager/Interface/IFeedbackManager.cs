using BookstoreModels;
using System.Collections.Generic;

namespace BookstoreManager.Interface
{
    public interface IFeedbackManager
    {
        string AddFeedback(FeedbackModel feedback);
        List<FeedbackModel> RetrieveOrderDetails(int bookId);
    }
}