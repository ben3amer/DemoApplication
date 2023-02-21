﻿namespace Application.Customer.Queries.GetCustomersList;
public class GetCustomersListVm
{
    public GetCustomersListVm(ICollection<CustomerDto> customers)
    {
        Customers = customers;
    }
    public ICollection<CustomerDto> Customers { get; set; }
}