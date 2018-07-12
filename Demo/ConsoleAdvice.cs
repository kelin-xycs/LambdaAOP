using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using LambdaAOP;

namespace Demo
{
    class ConsoleAdvice : IAroundAdvice
    {
        public object Invoke(object obj, MethodInfo mi, object[] args)
        {
            string typeMethodName = mi.DeclaringType.Name + "." + mi.Name + "()";

            Console.WriteLine(typeMethodName + " Begin .");

            Console.WriteLine("参数 ： ");

            ParameterInfo[] paraList = mi.GetParameters();

            for (int i = 0; i < paraList.Length; i++)
            {
                Console.WriteLine(paraList[i].Name + " = " + args[i]);
            }

            Console.WriteLine();

            object r = null;

            try
            {
                r = mi.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(typeMethodName + " Error : " + ex.ToString());
            }

            Console.WriteLine("\r\n" + typeMethodName + " End .\r\n");

            return r;
        }
    }
}
