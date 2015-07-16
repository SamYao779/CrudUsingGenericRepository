using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoCrudGenericRepository.Models.DB
{
    public class Contact
    {
        public int Id { get; set; }
        [Required, MaxLength(25)]
        public string FirstName { get; set; }
        [Required, MaxLength(25)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string Address { get; set; }
        [Required, EmailAddress, MaxLength(50)]
        public string Email { get; set; }
    }
}