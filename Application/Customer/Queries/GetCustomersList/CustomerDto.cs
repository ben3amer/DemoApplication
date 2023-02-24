using Application.Common.Mapping;
using AutoMapper;

using CustomerModel = Domain.Entities.Customer.Customer;

namespace Application.Customer.Queries.GetCustomersList;
public class CustomerDto : IMapFrom<CustomerModel>
{
    public int Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Phone { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CustomerModel, CustomerDto>();
    }

}