using System;
using System.Collections.Generic;
using System.Text;

namespace Wasted
{
    class FoodException : Exception
    {
        public FoodException()
        {
        }

        public FoodException(string message)
            : base(message)
        {
        }

        public FoodException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
