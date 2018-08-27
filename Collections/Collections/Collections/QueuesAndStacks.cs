using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class QueuesAndStacks
    {

        /*
           queue -  first-in, first-out (FIFO) type of collection.
                    You access elements in the same order you added them.
                    By getting an item, you also remove it from the queue.                      You can use a queue, for example, when you need to process incoming messages. Each new message is added to the end of the queue;             The Queue class has three important methods:
                ■ Enqueue adds an element to the end of the Queue, equivalent to the back of the line.
                ■ Dequeue removes the oldest element from the Queue, equivalent to the front of the line.
                ■ Peek returns the oldest element, but doesn’t immediately remove it from the Queue.
       */


        public static void Example()
        {
            Queue<string> myQueue = new Queue<string>();
            myQueue.Enqueue("Hello");
            myQueue.Enqueue("World");
            myQueue.Enqueue("From");
            myQueue.Enqueue("A");
            myQueue.Enqueue("Queue");
            foreach (string s in myQueue)
                Console.Write(s + " ");
            // Displays: Hello World From A Queue
        }

        /*
         Stack is a last-in, first-out (LIFO) collection
         Think of the undo system of an application. The last item added to the undo stack is the first.
             items are removed when reading them

        A Stack has the following three important methods:
            ■ Push Add a new item to the Stack.
            ■ Pop Get the newest item from the Stack.
            ■ Peek Get the newest item without removing it.
         */

        public static void ExampleOfStack()
        {
            Stack<string> myStack = new Stack<string>();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("From");
            myStack.Push("A");
            myStack.Push("Queue");
            foreach (string s in myStack)
                Console.Write(s + " ");
            // Displays: Queue A From World Hello
        }

    }
}
