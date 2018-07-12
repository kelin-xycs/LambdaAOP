using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaAOP
{
    class AopException : Exception
    {
        internal AopException(string message) : base(message)
        {

        }
    }
}
