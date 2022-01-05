using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookstoreModels
{
    public class BookDetailsModel
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        [Required]
        public int OriginalPrice { get; set; }
        [Required]
        public int DiscountedPrice { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int BookQty { get; set; }
        public string Image { get; set; }
    }
}
