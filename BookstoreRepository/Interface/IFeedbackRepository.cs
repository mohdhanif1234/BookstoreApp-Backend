using BookstoreModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BookstoreRepository.Repository
{
    public interface IFeedbackRepository
    {
        IConfiguration Configuration { get; }
        string AddFeedback(FeedbackModel feedback);
        List<FeedbackModel> RetrieveOrderDetails(int bookId);
    }
}