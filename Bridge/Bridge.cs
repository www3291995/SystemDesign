using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Bridge
{
    class Bridge
    {
        //static void Main(string[] args)
        //{
        //    //IRender renderer = new RasterRender();
        //    //var renderer = new VectorRender();
        //    //var circle = new Circle(renderer, 5);

        //    //circle.Draw();
        //    //circle.Resize(2);
        //    //circle.Draw();

        //    var cb = new ContainerBuilder();
        //    cb.RegisterType<VectorRender>().As<IRender>()
        //        .SingleInstance();
        //    cb.Register((c, p) => new Circle(c.Resolve<IRender>(), p.Positional<float>(0)));

        //    using (var c = cb.Build())
        //    {
        //        var circle = c.Resolve<Circle>(
        //            new PositionalParameter(0, 5.0f)
        //        );

        //        circle.Draw();
        //        circle.Resize(2);
        //        circle.Draw();
        //    }

        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public interface IRender
    {
        void RenderCircle(float radius);
    }

    public class VectorRender : IRender
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"draw circle of {radius}");
        }
    }

    public class RasterRender : IRender
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"draw pixels for circle of {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRender renderer;

        protected Shape(IRender renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float radius);
    }

    public class Circle : Shape
    {
        private float radius;

        public Circle(IRender renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }
}
