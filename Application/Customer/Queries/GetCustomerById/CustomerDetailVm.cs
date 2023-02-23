using Application.Common.Mapping;
using AutoMapper;

namespace Application.Customer.Queries.GetCustomerById;
public class CustomerDetailVm : IMapFrom<Domain.Entities.Customer.Customer>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Customer.Customer, CustomerDetailVm>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
    }
}
