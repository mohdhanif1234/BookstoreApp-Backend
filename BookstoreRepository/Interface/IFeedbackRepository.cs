using BookstoreModels;
using Microsoft.Extensions.Configuration;

namespace BookstoreRepository.Repository
{
    public interface IFeedbackRepository
    {
        IConfiguration Configuration { get; }
        string AddFeedback(FeedbackModel feedback);
    }
}