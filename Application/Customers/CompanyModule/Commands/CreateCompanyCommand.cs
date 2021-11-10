using Application.Responses;
using Domain.Customers;
using MediatR;

namespace Application.Customers.CompanyModule.Commands
{
    public class CreateCompanyCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
    }
}
