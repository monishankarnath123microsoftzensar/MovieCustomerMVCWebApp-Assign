using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieCustomerMVCwithAuthen.Models;

namespace MovieCustomerMVCwithAuthen.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        //public Customer Customer { get; set; }
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name Mandatory")]
        [StringLength(40, ErrorMessage = "Max length 40")]
        public string Name { get; set; }
        public bool IsSubscribe { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
        [Min18Yrs]
        public DateTime DOB { get; set; }
        public NewCustomerViewModel()
        {
            Id = 0;
        }
        public NewCustomerViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            IsSubscribe = customer.IsSubscribe;
            MembershipTypeId = customer.MembershipTypeId;
            DOB = customer.DOB;
        }
    }
}