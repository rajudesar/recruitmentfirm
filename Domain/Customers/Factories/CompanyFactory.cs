namespace Domain.Customers.Factories
{
    public class CompanyFactory : ICompanyFactory
    {
        private string companyName = default!;
        private string companyPhoneNumber = default!;
        private Address companyAddress = default!;
        private string companyDescription = default!;
        
        public ICompanyFactory WithName(string name)
        {
            this.companyName = name;
            return this;
        }
        public ICompanyFactory WithPhoneNumber(string phoneNumber)
        {
            this.companyPhoneNumber = phoneNumber;
            return this;
        }
        public ICompanyFactory WithAddress(Address address)
        {
            this.companyAddress = address;
            return this;
        }

        public ICompanyFactory WithDescription(string description)
        {
            this.companyDescription = description;
            return this;
        }

        public Company Build() => new Company(
            this.companyName,
            this.companyPhoneNumber,
            this.companyAddress, 
            this.companyDescription);
    }
}
