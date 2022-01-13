using BookstoreManager.Interface;
using BookstoreModels;
using BookstoreRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManager.Manager
{
    public class FeedbackManager : IFeedbackManager
    {
        private readonly IFeedbackRepository feedbackRepository;
        public FeedbackManager(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        public string AddFeedback(FeedbackModel feedback)
        {
            try
            {
                return this.feedbackRepository.AddFeedback(feedback);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<FeedbackModel> RetrieveOrderDetails(int bookId)
        {
            try
            {
                return this.feedbackRepository.RetrieveOrderDetails(bookId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
