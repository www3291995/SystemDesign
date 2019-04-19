using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

/// <summary>
/// Facade Coding Exercise
/// A magic square is a square matrix whose rows, columns and diagonals add up to the same value.
/// I have built a system that helps us construct magic squares, but it's a little bit complicated. At the moment, it is composed of three classes:
/// .Generator  makes an array of random digits (suitably constrained) of a particular length. You can use this generator several times to
///  build a square matrix of required size.
/// .Splitter  splits a 2D square matrix into several lists containing all rows, all columns and all diagonals.
/// .Verifier  ensures that, given a list of lists, every single list adds up to the same value.
/// Using all of the above, please implement a MagicSquareGenerator facade that uses all these three components to generate a valid
/// magic square of the required size.
/// </summary>
namespace DesignPattern.Facade
{
    class Exercise
    {
    }
    public class Generator
    {
        private static readonly Random random = new Random();

        public List<int> Generate(int count)
        {
            return Enumerable.Range(0, count)
                .OrderBy(_ => random.Next(1, 9)).Take(count)
                .ToList();
        }
    }

    public class Splitter
    {
        public List<List<int>> Split(List<List<int>> array)
        {
            var result = new List<List<int>>();

            var rowCount = array.Count;
            var colCount = array[0].Count;

            // get the rows
            for (int r = 0; r < rowCount; ++r)
            {
                var theRow = new List<int>();
                for (int c = 0; c < colCount; ++c)
                    theRow.Add(array[r][c]);
                result.Add(theRow);
            }

            // get the columns
            for (int c = 0; c < colCount; ++c)
            {
                var theCol = new List<int>();
                for (int r = 0; r < rowCount; ++r)
                    theCol.Add(array[r][c]);
                result.Add(theCol);
            }

            // now the diagonals
            var diag1 = new List<int>();
            var diag2 = new List<int>();
            for (int c = 0; c < colCount; ++c)
            {
                for (int r = 0; r < rowCount; ++r)
                {
                    if (c == r)
                        diag1.Add(array[r][c]);
                    var r2 = rowCount - r - 1;
                    if (c == r2)
                        diag2.Add(array[r][c]);
                }
            }

            result.Add(diag1);
            result.Add(diag2);

            return result;
        }
    }

    public class Verifier
    {
        public bool Verify(List<List<int>> array)
        {
            if (!array.Any()) return false;

            var expected = array.First().Sum();

            return array.All(t => t.Sum() == expected);
        }
    }

    public class MagicSquareGenerator
    {
        readonly List<List<int>> square = new List<List<int>>();

        public List<List<int>> Generate(int size)
        {
            var g = new Generator();
            var s = new Splitter();
            var v = new Verifier();

            while (true)
            {
                for (int k = 0; k < size; k++)
                {
                    var newG = g.Generate(size);
                    square.Add(newG);
                }

                var res = s.Split(square);

                if (v.Verify(res))
                    break;

                square.Clear();
                res.Clear();
            }

            return square;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var i in square)
            {
                foreach (var j in i)
                {
                    sb.Append(j + " ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void TestS()
        {

        }
    }
}
