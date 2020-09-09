using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCustomerMVCwithAuthen.Models;
using System.Data.Entity;
using MovieCustomerMVCwithAuthen.ViewModel;
using System.Net;
using System.Net.Http;

namespace MovieCustomerMVCwithAuthen.Controllers
{
    public class MovieController : Controller
    {
        
        //private ApplicationDbContext _context;
        //// GET: Movie
        //public MovieController()
        //{
        //    _context = new ApplicationDbContext();
        //}
        public ActionResult Index()
        {
            IEnumerable<Movie> movies;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("MovieApi").Result;
            movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            if (User.IsInRole("CanManageMovies"))
            {
                
                return View(movies);
            }
            else
            {
                //var mov = _context.Movies.Include(c=>c.Genre).ToList();
                return View("ReadOnlyList",movies);
            }
            //var mov = _context.Movies.Include(c=>c.Genre).ToList();
            //return View(mov);
        }
        public ActionResult Details(int id)
        {
            Movie movie;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("MovieApi?id=" + id.ToString()).Result;
            movie = response.Content.ReadAsAsync<Movie>().Result;
            return View(movie);
            //var singleMovie = _context.Movies.Include(c=>c.Genre).SingleOrDefault(c => c.Id == id);
            //if (singleMovie == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(singleMovie);
        }
        [Authorize(Roles = "CanManageMovies")]
        public ActionResult New()
        {
            HttpResponseMessage response1 = GlobalVariables.webApiClient.GetAsync("Genre").Result;

            var viewModel = new NewMovieViewModel
            {

                Genres = response1.Content.ReadAsAsync<IEnumerable<Genre>>().Result
            };
            //var genre = _context.Genres.ToList();
            //var viewModel = new NewMovieViewModel
            //{
            //    Genres = genre
            //};
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("MovieApi", movie).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync($"MovieApi/{movie.Id}", movie).Result;
            }
            return RedirectToAction("Index", "Movie");
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new NewMovieViewModel(movie)
            //    {
            //        Genres = _context.Genres.ToList()
            //    };
            //    return View("New", viewModel);
            //}
            //else
            //{
            //    //Customer customers;
            //    HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("MovieApi", movie).Result;
            //    //customers = response.Content.ReadAsAsync<Customer>().Result;
            //    return RedirectToAction("Index", "Movie");

            //}
        }
        //[HttpPost]
        //public ActionResult Create(Movie movie)//Model binding
        //{
        //    _context.Movies.Add(movie);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Movie");
        //}
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var movieTbl = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
        //    if (movieTbl == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Genres = new SelectList(_context.Genres, "Id", "GenreName", movieTbl.GenreId);
        //    return View(movieTbl);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "empId,empName,gender,empSal,DeptId")] EmployeeTbl employeeTbl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(employeeTbl).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.DeptId = new SelectList(db.deptTbls, "DeptId", "DeptName", employeeTbl.DeptId);
        //    return View(employeeTbl);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Save(Movie movie)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var viewModel = new NewMovieViewModel(movie)
        //        {
        //            Genres = _context.Genres.ToList()
        //        };
        //        return View("New",viewModel);
        //    }
        //    if (movie.Id == 0)
        //    {
        //        _context.Movies.Add(movie);
        //    }
        //    else
        //    {
        //        var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
        //        movieInDb.MovieName = movie.MovieName;
                
        //        movieInDb.GenreId = movie.GenreId;
                
        //    }
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Movie");
        //}
        public ActionResult Edit(int id)
        {
            Movie movie;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync($"MovieApi/{id}").Result;
            movie = response.Content.ReadAsAsync<Movie>().Result;
            HttpResponseMessage response1 = GlobalVariables.webApiClient.GetAsync("Genre").Result;

            var viewModel = new NewMovieViewModel(movie)
            {

                Genres = response1.Content.ReadAsAsync<IEnumerable<Genre>>().Result
            };
            return View("New", viewModel);
        }
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var movieTbl = _context.Movies.Include(c=>c.Genre).SingleOrDefault(c => c.Id == id);
        //    if (movieTbl == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movieTbl);
        //}

        ////POST: EmployeeTbls/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var movieTbl = _context.Movies.Find(id);
        //    _context.Movies.Remove(movieTbl);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index","Movie");
        //}
        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}
    }
}