﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VideoStoreManager.Models;
using VideoStoreManager.DTOs;
using AutoMapper;

namespace VideoStoreManager.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private MyDBContext _context;

        public MoviesController()
        {
            _context = new MyDBContext();
        }

        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDTO, Movie>(movieDTO, movieInDb);
            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }

    }
}