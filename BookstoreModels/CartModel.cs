﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreModels
{
    public class CartModel
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int QtyToOrder { get; set; }
        public BookDetailsModel BookModel { get; set; }
    }
}
