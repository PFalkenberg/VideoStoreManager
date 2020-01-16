using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoStoreManager.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int NumberInStock { get; set; }
    }
}