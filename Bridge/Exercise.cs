using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

/// <summary>
/// Bridge Coding Exercise
/// You are given an example of an inheritance hierarchy which results in Cartesian-product duplication.
/// Please refactor this hierarchy, giving the base class Shape a constructor that takes an interface IRenderer defined as
/// interface IRenderer
/// {
///     string WhatToRenderAs { get; }
/// }
/// as well as VectorRenderer and RasterRenderer classes. Each implementer of the Shape abstract class should have a constructor that
/// takes an IRenderer such that, subsequently, each constructed object's ToString() operates correctly, for example,
/// new Triangle(new RasterRenderer()).ToString() // returns "Drawing Triangle as pixels"
/// </summary>
namespace DesignPattern.Bridge.Exercise
{
    class Exercise
    {
    }
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public abstract class Shape
    {
        public string Name { get; set; }
        public IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public override string ToString()
        {
            return $"shape of {Name} with {renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        //public Triangle() => Name = "Triangle";
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }

    public class VectorSquare : IRenderer
    {
        public string WhatToRenderAs => $"lines";
    }

    public class RasterSquare : IRenderer
    {
        public string WhatToRenderAs => $"pixels";
    }

    // imagine VectorTriangle and RasterTriangle are here too

    [TestFixture]
    public class TestExercise
    {
        [Test]
        public void Test()
        {
            Assert.That(new Square(new VectorSquare()).ToString(), Is.EqualTo("shape of Square with lines"));
        }
    }
}
