using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesignPattern.Observer
{
    class Weak_Event_Pattern
    {
        //static void Main(string[] args)
        //{
        //    var btn = new Button();
        //    var window = new Window(btn);
        //    var windowRef = new WeakReference(window);

        //    btn.Fire();

        //    WriteLine("Setting window to null");
        //    window = null;

        //    FireGC();
        //    WriteLine($"Is the window alive after GC? {windowRef.IsAlive}");


        //    // ------------------------------------
        //    ReadLine();
        //}

        //private static void FireGC()
        //{
        //    WriteLine("starting GC");
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();
        //    GC.Collect();
        //    WriteLine("end GC");
        //}
    }

    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            WeakEventManager<Button, EventArgs>.AddHandler(button, "Clicked", ButtonClicked);
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button clicked (window handler)");
        }

        ~Window()
        {
            Console.WriteLine("Window finalized");
        }
    }
}
