using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VideoStoreManager.Models;

namespace VideoStoreManager.DTOs
{
    public class CustomerDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }

     //   [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}