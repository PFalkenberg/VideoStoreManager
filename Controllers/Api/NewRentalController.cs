using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoStoreManager.Models;
using VideoStoreManager.DTOs;

namespace VideoStoreManager.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private MyDBContext _context;

        public NewRentalController()
        {
            _context = new MyDBContext();
        }

        [HttpPost]
        public IHttpActionResult NewRental(NewRentalDTO rental)
        {

            if (rental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rental.CustomerId);
            if (customer == null)
                return BadRequest("CustomerId is not valid");

            var movies = _context.Movies.Where(
                m => rental.MovieIds.Contains(m.Id)).ToList();
            if (movies.Count != rental.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;
                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(newRental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
