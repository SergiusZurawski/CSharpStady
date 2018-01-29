using System;

namespace PartialTypes
{
    using System;
    partial class PartialMethodDemo
    {
        public PartialMethodDemo()
        {
            OnConstructorStart();
            Console.WriteLine("Generated constructor");
            OnConstructorEnd();
        }
        partial void OnConstructorStart();
        //partial methods are declared just like abstract methods: by providing the signature without any implementation but using the partial modifier.
        partial void OnConstructorEnd();
    }

}
