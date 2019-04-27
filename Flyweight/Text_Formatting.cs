using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Flyweight
{
    class Text_Formatting
    {
        //static void Main(string[] args)
        //{
        //    var ft = new FormattedText("This is a brave new world");
        //    ft.Capitalize(10, 15);
        //    WriteLine(ft);

        //    var bft = new BetterFormattedText("This is a brave new world");
        //    bft.GetRange(10, 15).Capitalize = true;
        //    bft.GetRange(0, 1).New = true;
        //    WriteLine(bft);


        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public class FormattedText
    {
        private readonly string plainText;
        private bool[] capitalize;

        public FormattedText(string plainText)
        {
            this.plainText = plainText;
            capitalize = new bool[plainText.Length];
        }

        public void Capitalize(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                capitalize[i] = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                sb.Append(capitalize[i] ? char.ToUpper(c) : c);
            }

            return sb.ToString();
        }
    }

    public partial class BetterFormattedText
    {
        private string plainText;
        private List<TextRange> formatting = new List<TextRange>();

        public BetterFormattedText(string plainText)
        {
            this.plainText = plainText;
        }

        public TextRange GetRange(int strat, int end)
        {
            var range = new TextRange { Start = strat, End = end };
            formatting.Add(range);
            return range;
        }

        public partial class TextRange
        {
            public int Start, End;
            public bool Capitalize, Bold, Italic;

            public bool Covers(int position)
            {
                return position >= Start && position <= End;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                foreach (var range in formatting)
                {
                    if (range.Covers(i) && range.Capitalize)
                        c = char.ToUpper(c);
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }

    public partial class BetterFormattedText
    {
        public partial class TextRange
        {
            public bool New;
        }
    }
}
