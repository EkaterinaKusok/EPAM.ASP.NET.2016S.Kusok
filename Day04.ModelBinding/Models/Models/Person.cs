﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
	public class Person
	{
        public Person()
        {
            this.HomeAddress = new Address();
        }

        public int PersonId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

		public Address HomeAddress { get; set; }
		public bool IsActive { get; set; }
		public Role Role { get; set; }
	}

    // [ModelBinder(typeof(AddressBinder))]
	public class Address
	{
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
        public string AddressSummary { get; set; }        
    }

    public enum Role
	{
		Admin,
		User,
		Guest
	}
}