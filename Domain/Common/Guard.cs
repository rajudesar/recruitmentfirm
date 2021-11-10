using System.Collections.Generic;

namespace Domain.Common
{
    public static class Guard
    {
        static List<string> stateList = new List<string>() { "state1", "state2" };
        public static void AgainstEmptyString<TException>(string value, string name = "Value")
            where TException : BaseException, new()
        {
            if (!string.IsNullOrEmpty(value))
                return;

            ThrowException<TException>($"{name} cannot be null or empty.");
        }

        public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
            where TException : BaseException, new()
        {
            AgainstEmptyString<TException>(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        public static void ForServiceRange<TException>(string state) where TException : BaseException, new()
        {
            if (stateList.Contains(state))
                return;
            ThrowException<TException>("Sorry we dont provide service here.");
        }
        private static void ThrowException<TException>(string message) where TException : BaseException, new()
        {
            var exception = new TException
            {
                Error = message
            };
            throw exception;
        }
    }
}
