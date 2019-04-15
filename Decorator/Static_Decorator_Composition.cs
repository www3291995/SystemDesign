using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator.Static_Decorator_Composition
{
    class Static_Decorator_Composition
    {
        //static void Main(string[] args)
        //{
        //    var redSq = new ColorShape<Square>("red");
        //    WriteLine(redSq.AsString());

        //    var trans = new TransparentShape<ColorShape<Circle>>(0.4f);
        //    WriteLine(trans.AsString());


        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public abstract class Shape
    {
        public abstract string AsString();
    }

    public class Circle : Shape
    {
        private float radius;

        public float Radius
        {
            get => radius;
            set => radius = value;
        }

        public Circle() : this(0.0f)
        {

        }

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public void Resize(float factor)
        {
            radius *= factor;
        }

        public override string AsString() => $"circle with radius {radius}";
    }

    public class Square : Shape
    {
        private float side;

        public Square() : this(0.0f)
        {
            
        }

        public Square(float side)
        {
            this.side = side;
        }

        public override string AsString() => $"square with side {side}";
    }

    public class ColorShape : Shape
    {
        private Shape shape;
        private string color;

        public ColorShape()
        {
            
        }

        public ColorShape(Shape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public override string AsString() => $"{shape.AsString()} has color {color}";
    }

    public class TransparentShape : Shape
    {
        private Shape shape;
        private float transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public override string AsString() => $"{shape.AsString()} transparency {transparency * 100}%";
    }

    public class ColorShape<T> : Shape where T : Shape, new()
    {
        private string color;
        private T shape = new T();

        public ColorShape() : this("black")
        {

        }

        public ColorShape(string color)
        {
            this.color = color;
        }

        public override string AsString() => $"{shape.AsString()} has color {color}";
    }

    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        private float transparency;
        private T shape = new T();

        public TransparentShape() : this(0)
        {

        }

        public TransparentShape(float transparency)
        {
            this.transparency = transparency;
        }

        public override string AsString() => $"{shape.AsString()} has transparency {transparency * 100}%";
    }

    //public class ColorShape<T> : T //CRTP
}
