using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataSharingInWithMultythreading
{
    public class Volatile
    {

        /// 
        /// ystem.Threading.Volatile. 
        /// This class has a special Write and Read method, 
        /// and those methods disable the compiler optimizations 
        /// so you can force the correct order in your code.
        ///  !! USE it only when you need it. Because it disables certain compiler optimizations, it will hurt performance
        public static void Example1()
        {
            var a = Task.Run(() => Thread1());
            var b = Task.Run(() => Thread2());
           
            a.Wait();
            b.Wait();
        }

        //private static int _flag = 0;
        private static volatile int _flag = 0;
        private static int _value = 0;


        public static void Thread1()
        {
            _value = 5;
            _flag = 1;
        }

        public static void Thread2()
        {
            if (_flag == 1)
                Console.WriteLine(_value);
        }



    }
}
