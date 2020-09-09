using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieCustomerMVCwithAuthen.Models;

namespace MovieCustomerMVCwithAuthen.Controllers.Api
{
    public class MembershipTypeController : ApiController
    {
        private ApplicationDbContext _context;
        public MembershipTypeController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetMembershipType()
        {
            var memberships = _context.MembershipTypes.ToList();
            return Ok(memberships);

        }
    }
}
