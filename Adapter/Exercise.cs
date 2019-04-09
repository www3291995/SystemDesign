using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

/// <summary>
/// Adapter Coding Exercise
/// Here's a very synthetic example for you to try.
/// You are given an IRectangle interface and an extension method on it. Try to define a SquareToRectangleAdapter that adapts the
/// Square to the IRectangle interface. 
/// </summary>
namespace DesignPattern.Adapter
{
    class Exercise
    {
    }


    public class Square 
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square square;
        public SquareToRectangleAdapter(Square square)
        {
            this.square = square;
        }

        public int Width => square.Side;
        public int Height => square.Side;
    }

    [TestFixture]
    public class TestSquareToRectangle
    {
        [Test]
        public void TestSquareToRectangleAdapter()
        {
            var square = new Square{Side = 15};
            var adapter = new SquareToRectangleAdapter(square);

            Assert.That(adapter.Area(), Is.EqualTo(225));
        }
    }
}
