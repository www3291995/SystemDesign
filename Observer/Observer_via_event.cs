using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    class Observer_via_event
    {
        //static void Main(string[] args)
        //{
        //    var person = new Person();
        //    person.FallsIll += CallDoctor;
        //    person.CatchACold();
        //    person.FallsIll -= CallDoctor;
        //    person.CatchACold();





        //    // ------------------------------------
        //    ReadLine();
        //}

        //private static void CallDoctor(object sender, FallsIllEventArgs e)
        //{
        //    WriteLine($"A doctor has been called to {e.Address}");
        //}
    }

    public class FallsIllEventArgs
    {
        public string Address;
    }

    public class Person
    {
        public event EventHandler<FallsIllEventArgs> FallsIll;

        public void CatchACold()
        {
            FallsIll?.Invoke(this, new FallsIllEventArgs {Address = "123 address"});
        }
    }
}
