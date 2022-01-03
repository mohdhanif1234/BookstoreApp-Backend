using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookstoreModels
{
    public class RegisterModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public long MobileNum { get; set; }
    }
}
