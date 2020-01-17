using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoStoreManager.Models
{
    public class NumberInStockValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.NumberInStock >= Movie.MinStock && movie.NumberInStock <= Movie.MaxStock)
                return ValidationResult.Success;
            else
                return new ValidationResult("The Number in Stock field must be a number between 1 and 20.");

        }
    }
}