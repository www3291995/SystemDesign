using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Composite
{
    class Neural_Networks
    {
        //static void Main(string[] args)
        //{
        //    var neuron1 = new Neuron();
        //    var neuron2 = new Neuron();

        //    //1
        //    neuron1.ConnectTo(neuron2);

        //    var layer1 = new NeuronLayer();
        //    var layer2 = new NeuronLayer();

        //    //4
        //    neuron1.ConnectTo(layer1);
        //    layer1.ConnectTo(layer2);



        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public static class ExtensionMethod
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other)) return;

            foreach (var from in self)
            foreach (var to in other)
            {
                from.Out.Add(to);
                to.In.Add(from);
            }
        }
    }

    public class Neuron : IEnumerable<Neuron>
    {
        public float value;
        public List<Neuron> In, Out;

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {

    }

//    public class NeuronRing : List<Neuron>
//    {
//
//    }
}
