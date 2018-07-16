using System;
using System.Linq.Expressions;

namespace ExpressionThree
{
    /*
      expression trees, which are representations of code in a tree-like data structure
      System.Linq.Expressions 
      https://msdn.microsoft.com/en-us/library/bb397951.aspx
    */
    class Program
    {
        static void Main(string[] args)
        {
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                    null, 
                    typeof(Console).GetMethod("Write", new Type[] { typeof(String) }), 
                    Expression.Constant("Hello")
                ), 
                Expression.Call(
                    null, 
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }), 
                    Expression.Constant("World!"))
                );
            Expression.Lambda<Action>(blockExpr).Compile()();
        }
    }
}
