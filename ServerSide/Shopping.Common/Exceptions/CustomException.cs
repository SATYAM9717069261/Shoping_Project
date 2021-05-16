using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Exceptions
{
    public class CustomException:Exception
    {
        public CustomException(string message) : base(message) { } 
        public string UserException(string message)
        {
            return "Please Try again later "+message;
        }
    }
}
