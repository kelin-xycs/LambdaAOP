using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace LambdaAOP
{
    public interface IAroundAdvice
    {
        object Invoke(object obj, MethodInfo mi, object[] args);
    }
}
