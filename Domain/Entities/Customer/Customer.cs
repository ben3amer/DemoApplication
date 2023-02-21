using Domain.Common;

namespace Domain.Entities.Customer;
public class Customer : BaseAuditableEntity
{
    public Customer(int id, string firstName, string lastName, string phone)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
}
