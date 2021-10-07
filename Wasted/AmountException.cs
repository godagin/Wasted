using System;
using System.Collections.Generic;
using System.Text;

namespace Wasted
{
    class NotSuitableAmountException : FoodException
    {
        public NotSuitableAmountException() 
        { 
        }

        public NotSuitableAmountException(string message)
            : base(message)
        {
        }

        public NotSuitableAmountException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
