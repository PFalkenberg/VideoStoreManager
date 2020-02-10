using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoStoreManager.Models;
using VideoStoreManager.DTOs;
using System.Data.Entity;

namespace VideoStoreManager.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private MyDBContext _context;

        public NewRentalController()
        {
            _context = new MyDBContext();
        }

        [HttpGet]
        public IHttpActionResult GetAllRentals()
        {
            var Rentals = _context.Rentals.ToList();
            return Ok(Rentals);
        }

        [HttpGet]
        public IHttpActionResult GetRental(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.Id == id);
            if (rental == null)
                return NotFound();

            return Ok(rental);
        }

        [HttpGet]
        public IHttpActionResult GetCustomerRentals(int customerId) //Gets all active rentals for a specific customer
        {
            var Rentals = _context.Rentals
                .Include(r => r.Movie)
                .Where(r => r.Customer.Id == customerId)
                .Where(r => r.DateReturned == null)
                .ToList();

            if (Rentals == null)
                return NotFound();

            return Ok(Rentals);
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

            if (customer.ActiveRentals + movies.Count > Customer.RentalLimit)
                return BadRequest("Customer cannot rent more than 3 movies at a time.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;
                customer.ActiveRentals++;
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

        [HttpPut]
        public void ReturnRental(int id)
        {
            var rentalInDb = _context.Rentals
                .Include(r => r.Movie)
                .SingleOrDefault(r => r.Id == id);

            if(rentalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            rentalInDb.DateReturned = DateTime.Now;

            var movieId = rentalInDb.Movie.Id;
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movieId);
            
            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            movieInDb.NumberAvailable++;
            _context.SaveChanges();
        }
    }
}
