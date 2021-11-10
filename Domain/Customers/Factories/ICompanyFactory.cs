using Domain.Common;

namespace Domain.Customers.Factories
{
    public interface ICompanyFactory : IFactory<Company>
    {
        ICompanyFactory WithName(string name);
        ICompanyFactory WithPhoneNumber(string phoneNumber);
        ICompanyFactory WithAddress(Address address);
        ICompanyFactory WithDescription(string description);
    }
}
