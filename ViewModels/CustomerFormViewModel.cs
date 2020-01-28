using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStoreManager.Models;
using System.ComponentModel.DataAnnotations;

namespace VideoStoreManager.ViewModels
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            BirthDate = customer.BirthDate;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            MembershipTypeId = customer.MembershipTypeId;
        }

        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        [Required]
        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public int? MembershipTypeId { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }


        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Manage Customer";
                return "New Customer";
            }
        }
    }
}