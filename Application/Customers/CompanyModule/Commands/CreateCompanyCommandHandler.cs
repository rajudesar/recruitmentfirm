using Application.Responses;
using Domain.Customers;
using Domain.Customers.Factories;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.CompanyModule.Commands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, BaseResponse>
    {
        private readonly ApplicationContext _context;
        private readonly ICompanyFactory _companyFactory;
        private readonly ICustomerRepository _customerRepository;
        public CreateCompanyCommandHandler(ApplicationContext context, 
            ICompanyFactory companyFactory,
            ICustomerRepository customerRepository)
        {
            _context = context;
            _companyFactory = companyFactory;
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var companyRepo = _context.Companies;
                var company = _companyFactory.WithName(request.CompanyName)
                    .WithPhoneNumber(request.PhoneNumber)
                    .WithAddress(request.Address)
                    .WithDescription(request.Description)
                    .Build();

                await _customerRepository.Update(company);

                //Raise event like CompanyAddedEvent

                return new BaseResponse()
                {
                    Success = true,
                    Message = $"{request.CompanyName} created successfully"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Success = false,
                    Message = ex?.Message
                };
            }
        }

    }
}
