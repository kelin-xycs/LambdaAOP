using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LambdaAOP;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Aop.AddAdvice(new ConsoleAdvice());

            int i = 12;
            string s = "hello";

            Aop.Exec(() => Foo());

            Aop.Exec(() => Foo2(3));

            Aop.Exec(() => Foo2(i));

            Aop.Exec(() => Foo3(3, "hi"));

            Aop.Exec(() => Foo3(i, s));

            string r = Aop.Exec<string>(() => Foo4(i, s));

            Console.WriteLine("返回值 ： " + r);

            TestObj o = new TestObj();

            Aop.Exec(() => o.Test());

            Aop.Exec(() => o.Test2(3));

            Aop.Exec(() => o.Test2(i));

            Aop.Exec(() => o.Test3(3, "hi"));

            Aop.Exec(() => o.Test3(i, s));

            r = Aop.Exec<string>(() => o.Test4(i, s));

            Console.WriteLine("返回值 ： " + r);

            Console.ReadLine();
        }

        static void Foo()
        {
            Console.WriteLine("Foo: ");
        }

        static void Foo2(int i)
        {
            Console.WriteLine("Foo2: i = " + i);
        }

        static void Foo3(int i, string s)
        {
            Console.WriteLine("Foo3: i = " + i + " s = " + s);
        }

        static string Foo4(int i, string s)
        {
            Console.WriteLine("Foo4: i = " + i + " s = " + s);

            return "haha";
        }
    }

    class TestObj
    {
        public void Test()
        {
            Console.WriteLine("Test: ");
        }

        public void Test2(int i)
        {
            Console.WriteLine("Test2: i = " + i);
        }

        public void Test3(int i, string s)
        {
            Console.WriteLine("Test3: i = " + i + " s = " + s);
        }

        public string Test4(int i, string s)
        {
            Console.WriteLine("Test4: i = " + i + " s = " + s);

            return "haha";
        }
    }
}
