using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPattern
{
    class Demo
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small, Brand.Apple);
            var tree = new Product("Tree", Color.Green, Size.Large, Brand.Samsung);
            var house = new Product("House", Color.Blue, Size.Large, Brand.Samsung);

            Product[] products = { apple, tree, house };

            var bf = new BetterFilter();

            IList<ISpecification<Product> > pf = new List<ISpecification<Product>>();
            pf.Add(new ColorSpecification(Color.Green));
            pf.Add(new SizeSpecification(Size.Small));
            pf.Add(new BrandSpecification(Brand.Apple));
            var mulF = new MultiSpecification<Product>(pf);

            foreach (var f in bf.Filter(products, mulF))
            {
                WriteLine($"find {f.Name}");
            }

            ReadLine();
        }
    }
}
