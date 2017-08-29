using System;
using System.Threading;
using static Threads.SimpleThread;

namespace Tutorial
{
    public static class Tutorial
    {
       
        public static void Main()
         {
             //Threads.SimpleThread.CallExample();
             Threads.SimpleThread.CallExampleThreadLocal();
             //CallExampleBackGroundProcess
         }

    }
}
