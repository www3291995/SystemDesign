using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    class Dynamic_Decorator_Composition
    {
        //static void Main(string[] args)
        //{
        //    var square = new Square(1.23f);
        //    WriteLine(square.AsString());

        //    var redSq = new ColorShape(square, "red");
        //    WriteLine(redSq.AsString());

        //    var trans = new TransparentShape(redSq, 0.5f);
        //    WriteLine(trans.AsString());


        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public interface IShape
    {
        string AsString();
    }

    public class Circle : IShape
    {
        private float radius;

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public void Resize(float factor)
        {
            radius *= factor;
        }

        public string AsString() => $"circle with radius {radius}";
    }

    public class Square : IShape
    {
        private float side;

        public Square(float side)
        {
            this.side = side;
        }

        public string AsString() => $"square with side {side}";
    }

    public class ColorShape : IShape
    {
        private IShape shape;
        private string color;

        public ColorShape(IShape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public string AsString() => $"{shape.AsString()} has color {color}";
    }

    public class TransparentShape : IShape
    {
        private IShape shape;
        private float transparency;

        public TransparentShape(IShape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public string AsString() => $"{shape.AsString()} transparency {transparency * 100}%";
    }
}
