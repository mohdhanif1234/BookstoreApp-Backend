﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreModels
{
    public class WishlistModel
    {
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public BookDetailsModel bookDetailsModel { get; set; }
    }
}
