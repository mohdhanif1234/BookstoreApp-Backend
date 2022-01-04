using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookstoreModels
{
    public class ResetPasswordModel
    {
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
