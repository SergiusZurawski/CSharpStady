using System;
using System.Collections.Generic;
using System.Threading;

// |out| - covariant 	  from more specific to more generic;
// |in | - contravariant  from more generic  to more specific;

// Read-only data types (sources) can be covariant; 
// write-only data types (sinks) can be contravariant. 
// Mutable data types which act as both sources and sinks should be invariant

/*
IEnumerable<Cat> is a subtype of IEnumerable<Animal>. The subtyping is preserved because IEnumerable<T> is covariant on T.
Action<Animal> is a subtype of Action<Cat>. The subtyping is reversed because Action<T> is contravariant on T.
Neither IList<Cat> nor IList<Animal> is a subtype of the other, because IList<T> is invariant on T.
*/

namespace GenericsAttributes
{
   public class ProgramExample
    {
        public static void Example()
        {
            // ---Returning --- without Generics
            A a = getValues();
            A a1 = getValuesB();
            A b = getValuesB1();
            // ---Setting ---
            B b1 = new B();
            setValuesA(b1);
            
        }
        
        static A getValues(){
            return new A();
        }
        
        static A getValuesB(){
            return new B();
        }
        
        static B getValuesB1(){
            return new B();
        }
        
        
        static void setValuesA(A a){
            A someA = a;
        }
        
        static void covarianceInArrays()
        {
            A [] arrA = new A[]{new A()};
            B [] arrB = new B[]{new B()};
            C [] arrC = new C[]{new C()};
            //covariance
            arrA = new B[]{new B()};
            //contrvariance doesn't work
            
            //arrB = new A[]{new A()};
            
            //Logically downs't work
            //arrC = new C[]{new C()};
            
        }
        
        //invariant
        // Becase the list interface has methods for set and get
        static void covarianceInGenerics()
        {
            
            List<A> lA = new List<A>{new A()};
            List<B> lB = new List<B>{new B()};
            List<C> lC = new List<C>{new C()};	
            
            //covariance Doesn't Work
            //lA = new List<B>{new B()};
            
            //contrvariance doesn't work
            //lB = new List<A>{new A()};
            
            //Logically 
            //lC = new List<B>{new B()};
            
        }
        
        //contravariant
        static void contravariantActionExaple()
        {
            Action<A> acA = new Action<A>((a) => Console.WriteLine("Action A"));
            Action<B> acB = new Action<B>((b) => Console.WriteLine("Action B"));
            
            //acA = acB;
            acB = acA;
            
            //Inheritance rule still works for parameters
            acB = new Action<B>((b) => Console.WriteLine("Action B"));
            B someB = new B();
            A someA = new A();
            acA(someB);
            //convariance doesn't work
            //acB(someA);
        }
        
        /*  Func<in T, out TResult> represents a function with a contravariant input parameter of type T and a covariant return value of type TResult*/
        static void outInOnFucnExaple()
        {
            Func<B, B> function;
            function = delegate(B b){ return b;}; 
            
            /* anonimus delegates doesn't work
            function = delegate(D b){ return new B();}; 
            function = delegate(A a){ return new B();};
            
            lambda doesn't work as well
            function = (A a) => new B();
            function = (D d) => new B();
            */
            
            //Works input is in contrvariant A to B
            function = test;
            
            // Exeption. Doesn't work uput type is Covarian D to B
            //function = test1;
            
            
            //verify that output is covariant
            function = delegate(B b){ return new D();};
            //Exception
            //function = delegate(B b){ return new A();};
            
            
        }
        static B test(A a){
            return new B();
        }
        
        static B test1(D d){
            return new B();
        }
        
        
    }


    class A
    {
        public A(){Console.WriteLine("A");}
    }
    class B:A
    {
        public B(){Console.WriteLine("B");}
    }
    class D:B
    {
        public D(){Console.WriteLine("D");}
    }

    class C:A
    {
        public C(){Console.WriteLine("C");}
    }

    //inheritance example
}
