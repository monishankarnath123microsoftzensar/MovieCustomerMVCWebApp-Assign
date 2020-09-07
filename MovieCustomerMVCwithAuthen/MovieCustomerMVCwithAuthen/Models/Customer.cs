using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMVCwithAuthen.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Mandatory")]
        [StringLength(40,ErrorMessage ="Max length 40")]
        public string Name { get; set; }
        public bool IsSubscribe { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
        [Min18Yrs]
        public DateTime DOB { get; set; }
    }
}