using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface IFeedbackManager
    {
        string AddFeedback(FeedbackModel feedback);
    }
}