using System;

namespace DataFinder.DataFinder.BLL
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message) : base(message) { }
    }
}
