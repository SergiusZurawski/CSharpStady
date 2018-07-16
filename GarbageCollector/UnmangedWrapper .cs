using System;
using System.IO;

namespace GarbageCollector
{
    public  class UnmangedWrapper : IDisposable 
    {     
        public FileStream Stream { get; private set; }

        public UnmangedWrapper()
        {
            this.Stream = File.Open("temp.dat", FileMode.Create);
        }
        ~UnmangedWrapper() { Dispose(false); }
        public void Close() { Dispose(); }
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Stream != null)
                {
                    Stream.Close();
                }
            }
        }
    }
    /*
     1. The finalizer only calls Dispose passing false for disposing.
     2. The extra Dispose method with the Boolean argument does the real work.
         This method checks if it’s being called in an explicit Dispose or if it’s being called from the finalizer: 
         2.1.  If the finalizer calls Dispose, you do nothing because the Stream object also implements a finalizer, 
                and the garbage collector takes care of calling the finalizer of the Stream instance. 
                You can’t be sure if it’s already called, so it’s best to leave it up to the garbage collector. 
         2.2. If Dispose is called explicitly, you close the underlying FIleStream. 
                It’s important to be defensive in coding this method; always check for any source of possible exceptions. 
                It could be that Dispose is called multiple times and that shouldn’t cause any errors. 
     3. The regular Dispose method calls GC.SuppressFinalize(this) to make sure that the object 
            is removed from the finalization list that the garbage collector is keeping track of. 
            The instance has already cleaned up after itself, so it’s not necessary that the garbage collector call the finalizer.

     */
}
