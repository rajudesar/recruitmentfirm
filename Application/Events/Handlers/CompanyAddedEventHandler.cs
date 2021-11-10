using Domain.Customers.Events;
using System;
using System.Threading.Tasks;

namespace Application.Events.Handlers
{
    public class CompanyAddedEventHandler : IEventHandler<CompanyAddedEvent>
    {
        public Task Handle(CompanyAddedEvent domainEvent)
        {
            //Logic to perform after company added
            throw new NotImplementedException();
        }
    }
}
