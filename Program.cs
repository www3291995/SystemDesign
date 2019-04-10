using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DesignPattern.Composite;
using MoreLinq;
using static System.Console;

namespace DesignPattern
{
    class Demo
    {
        static void Main(string[] args)
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            //1
            neuron1.ConnectTo(neuron2);

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            //4
            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);



            // ------------------------------------
            ReadLine();
        }
    }
}
