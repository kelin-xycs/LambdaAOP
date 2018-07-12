using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using System.Linq.Expressions;

namespace LambdaAOP
{
    public class Aop
    {

        private static IAroundAdvice _advice;

        public static void AddAdvice(IAroundAdvice advice)
        {
            if (_advice != null)
                throw new AopException("Advice 已存在 ， 目前只支持一个 Advice 。");

            _advice = advice;
        }

        public static object Exec(Expression<Action> lambda)
        {
            Expression body = lambda.Body;

            if (body == null || body.NodeType != ExpressionType.Call)
                throw new AopException("lambda 表达式内应包含一个方法调用的表达式 。");


            MethodCallExpression bodyM = (MethodCallExpression)body;
            
            MemberExpression m;
            ConstantExpression c;
            FieldInfo f;
            ConstantExpression cc;

            object[] args = new object[bodyM.Arguments.Count];
            
            Expression arg;

            for(int i = 0; i<bodyM.Arguments.Count; i++)
            {
                arg = bodyM.Arguments[i];

                c = arg as ConstantExpression;

                if (c != null)
                {
                    args[i] = c.Value;
                    continue;
                }

                m = arg as MemberExpression;

                if (m != null)
                {
                    f = m.Member as FieldInfo;

                    if (f == null)
                        throw new AopException("参数 是 MemberExpression ， 但 MemberExpression 的 Member 属性不是 FieldInfo 类 ， 而是 " + m.Member.GetType() + " 。");

                    cc = m.Expression as ConstantExpression;

                    if (cc == null)
                        throw new AopException("参数 是 MemberExpression ， 但 MemberExpression 的 Expression 属性不是 ConstantExpression 类 ， 而是 " + m.Expression.GetType() + " 。");

                    args[i] = f.GetValue(cc.Value);
                    continue;
                }

                throw new AopException("参数应该是 常量 或 变量 ， 不能是其它表达式。");
            }


            object o = null;

            if (bodyM.Object != null)
            {
                m = bodyM.Object as MemberExpression;

                if (m == null)
                    throw new AopException("调用 实例方法（Instance Method）的实例（对象）应该是 变量 ， 不能是其它表达式。");

                f = m.Member as FieldInfo;

                if (f == null)
                    throw new AopException("对象（实例） 是 MemberExpression ， 但 MemberExpression 的 Member 属性不是 FieldInfo 类 ， 而是 " + m.Member.GetType() + " 。");

                cc = m.Expression as ConstantExpression;

                if (cc == null)
                    throw new AopException("对象（实例） 是 MemberExpression ， 但 MemberExpression 的 Expression 属性不是 ConstantExpression 类 ， 而是 " + m.Expression.GetType() + " 。");

                o = f.GetValue(cc.Value);
            }



            if (_advice == null)
                throw new AopException("缺少 Advice ， 请先调用 AddAdvice() 方法 添加 Advice 。");


            return _advice.Invoke(o, bodyM.Method, args);

        }

        public static T Exec<T>(Expression<Action> lambda)
        {
            return (T)Exec(lambda);
        }
    }
}
