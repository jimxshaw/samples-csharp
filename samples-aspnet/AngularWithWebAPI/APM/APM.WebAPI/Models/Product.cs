using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace APM.WebAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required", AllowEmptyStrings = false)]
        [MinLength(5, ErrorMessage = "Product name min length is 5 characters")]
        [MaxLength(19, ErrorMessage = "Product name max length is 19 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product code is required", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "Produce code min length is 6 characters")]
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}