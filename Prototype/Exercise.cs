using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

//Given the definitions above, you are asked to implement Line.DeepCopy() to perform a deep copy of the current Line object
namespace DesignPattern.Prototype
{
    class Exercise
    {
        //static void Main(string[] args)
        //{
        //    var line1 = new Line(new Prototype.Point(1, 1), new Prototype.Point(2, 2));
        //    WriteLine(line1.ToString());

        //    var line2 = line1.DeepCopy();
        //    line2.End.Y = 3;
        //    WriteLine(line2);


        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    [Serializable]
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }

    [Serializable]
    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Line DeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, this);
                ms.Position = 0;
                return (Line)bf.Deserialize(ms);
            }
        }

        public override string ToString()
        {
            return $"{nameof(Start)}: {Start.ToString()}, {nameof(End)}: {End.ToString()}";
        }
    }
}
