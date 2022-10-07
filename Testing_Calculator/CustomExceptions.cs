using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Calculator
{
    internal class CustomExceptions : Exception
    {
        [Serializable]
        public class NonNumericException : Exception
        {
            public NonNumericException()
                : base("You can only enter numeric values")
            {
            }
        }

        [Serializable]
        public class NonOperandException : Exception
        {
            public NonOperandException()
                : base("That is not an operand")
            {
            }
        }
    }
}
