using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// don't put too much into an interface; split into separate interfaces
// YAGNI - you ain't goint to need it
namespace DesignPattern
{
    class interface_Segregation_Principle
    {
    }

    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScaner
    {
        void Scan(Document d);
    }

    public interface IFaxer
    {
        void Fax(Document d);
    }

    public interface IMultifunctionDevice: IPrinter, IScaner, IFaxer
    {

    }

    public class MultiFuncPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    public class OldFashsionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public class Photocopier : IPrinter, IScaner
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiFuncMachine : IMultifunctionDevice
    {
        private IPrinter printer;
        private IScaner scaner;
        private IFaxer faxer;

        public MultiFuncMachine(IPrinter printer,
            IScaner scaner,
            IFaxer faxer)
        {
            this.printer = printer ?? throw new ArgumentNullException(nameof(printer));
            this.scaner = scaner ?? throw new ArgumentNullException(nameof(scaner));
            this.faxer = faxer ?? throw new ArgumentNullException(nameof(faxer));
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Fax(Document d)
        {
            faxer.Fax(d);
        }

        public void Scan(Document d)
        {
            scaner.Scan(d);
        }
    }
}
