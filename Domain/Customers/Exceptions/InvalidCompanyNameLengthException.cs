using Domain.Common;

namespace Domain.Customers.Exceptions
{
    public class InvalidCompanyNameLengthException : BaseException
    {
        public InvalidCompanyNameLengthException()
        {
                
        }
        public InvalidCompanyNameLengthException(string error) => this.Error = error;
    }    
}
