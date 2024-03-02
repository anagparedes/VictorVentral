﻿using System.ComponentModel.DataAnnotations;

namespace VictorVentralCustomer.Application.Customers.Dtos
{
    public class CreatedCustomerResponse
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
