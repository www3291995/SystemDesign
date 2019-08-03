using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace DesignPattern.Observer
{
    class Observable_Properties_and_Sequences
    {
        //static void Main(string[] args) // observer
        //{
        //    var market = new Market();
        //    ///1
        //    //market.PropertyChanged += (sender, EventArgs) =>
        //    //{
        //    //    if (EventArgs.PropertyName == "volatility")
        //    //    {

        //    //    }
        //    //};

        //    ///2
        //    //market.PriceAdded += (sender, f) =>
        //    //{
        //    //    WriteLine($"we got price of {f}");
        //    //};

        //    ///3
        //    market.Prices.ListChanged += (sender, EventArgs) =>
        //    {
        //        if (EventArgs.ListChangedType == ListChangedType.ItemAdded)
        //        {
        //            float price = ((BindingList<float>)sender)[EventArgs.NewIndex];
        //            WriteLine($"binding list price {price}");
        //        }
        //    };

        //    market.AddPrice(12);
        //    market.AddPrice(123);







        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public class Market // observable
    {
        ///1
        //: INotifyPropertyChanged
        //private float volatility;

        //public float Volatility
        //{
        //    get => volatility;
        //    set
        //    {
        //        if (value.Equals(volatility)) return;
        //        volatility = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}


        /// 2
        //private List<float> prices = new List<float>();

        //public void AddPrice(float price)
        //{
        //    prices.Add(price);
        //    PriceAdded?.Invoke(this, price);
        //}

        //public event EventHandler<float> PriceAdded;

        ///3
        public BindingList<float> Prices = new BindingList<float>();

        public void AddPrice(float price)
        {
            Prices.Add(price);
        }
    }
}
