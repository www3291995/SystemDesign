

// should be able to substitute a base type for a subtype
namespace DesignPattern.SOLID
{
    public class Liskov_Substitution_Principle
    {

    }
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set
            {
                base.Width = base.Height = value;
            }
        }

        public override int Height
        {
            set
            {
                base.Width = base.Height = value;
            }
        }
    }
    //static public int Area(Rectangle r) => r.width * r.height;
    //static void Main(string[] args)
    //{
    //    Rectangle rec = new Rectangle(2, 3);
    //    WriteLine($"{rec} has Area {Area(rec)}");

    //    Rectangle sq = new Square();
    //    sq.width = 4;
    //    WriteLine($"{sq} has Area {Area(sq)}");


    //    ReadLine();
    //}
}
