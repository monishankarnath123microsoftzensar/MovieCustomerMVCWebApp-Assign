using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieCustomerMVCwithAuthen.Models;
using System.Data.Entity;

namespace MovieCustomerMVCwithAuthen.Controllers.Api
{
    public class CustomerApiController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerApiController()
        {
            _context = new ApplicationDbContext();
        }
        //Get /api/customerapi
        public IHttpActionResult GetCustomers()
        {
            var customer = _context.Customers.Include(m=>m.MembershipType).ToList();
            //return customer;
            //return _context.Customers.ToList();
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }
                
            return Ok(customer);
        }
        //Post /api/customerapi
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest("Model data is invalid");
            }
                
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
        //Put /api/customerapi/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest("Model data is invalid");
            }
            var customerInDb = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if(customerInDb == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }
                
            customerInDb.Name = customer.Name;
            customerInDb.DOB = customer.DOB;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribe = customer.IsSubscribe;
            _context.SaveChanges();
            return Ok();
        }
        //Delete /api/customerapi/1
        
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a Valid Customer id");
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }
                
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
