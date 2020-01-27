using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VideoStoreManager.Models;

namespace VideoStoreManager.DTOs
{
    public class MovieDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
     //  [NumberInStockValidation]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
    }
}