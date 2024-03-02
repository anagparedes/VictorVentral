using System.ComponentModel.DataAnnotations;
using VictorVentralCustomer.Domain.Models;

namespace VictorVentralCustomer.Domain.Entities
{
    public class Customer: BaseEntity
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public DateTimeOffset? RegistrationDate { get; set; }
        public DateTimeOffset? LastPurchaseDate { get; set; }

    }
}
