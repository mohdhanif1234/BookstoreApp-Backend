using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreModels
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int BookId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string OrderDate { get; set; }
        public BookDetailsModel bookDetailsModel { get; set; }
    }
}
