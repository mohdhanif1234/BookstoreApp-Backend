using BookstoreManager.Interface;
using BookstoreModels;
using BookstoreRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManager.Manager
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository orderRepository;
        public OrderManager(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public string AddOrder(OrderModel orderModel)
        {
            try
            {
                return this.orderRepository.AddOrder(orderModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
