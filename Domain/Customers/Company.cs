using Domain.Common;
using Domain.Customers.Exceptions;

namespace Domain.Customers
{
    public class Company : Entity<int>, IAggregateRoot
    {
        internal Company(string companyName, string phoneNumber, Address address, string description)
        {
            this.Validate(companyName, address.State);
            this.CompanyName = companyName;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Description = description;
        }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }       
        private void Validate(string companyName, string state)
        {
            Guard.ForStringLength<InvalidCompanyNameLengthException>(
                companyName,
                Constants.Company.MinNameLength,
                Constants.Company.MaxNameLength,
                nameof(this.CompanyName));

            Guard.ForServiceRange<InvalidCompanyNameLengthException>(state);
        }
    }
}
