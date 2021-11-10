
using Domain.Common;

namespace Domain.Customers.Exceptions
{
    public class InvalidServiceLocationException : BaseException
    {
        public InvalidServiceLocationException()
        {

        }
        public InvalidServiceLocationException(string error) => this.Error = error;
    }
}
