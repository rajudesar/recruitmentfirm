using Domain.Common;
using System.Threading.Tasks;

namespace Application.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
