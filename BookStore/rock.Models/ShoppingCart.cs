using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace rock.Models
{ public class ShoppingCart
    {
        
        public Product product { get; set; }
        [Range(1,1000,ErrorMessage = "Please enter  a value between 1 and 1000")]
        public int Count { get; set; }
        
        
    }
}

