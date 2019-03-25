using System;
using System.Collections.Generic;

// class should open for extension but closed for modification
namespace DesignPattern
{
    class open_closedPrinciple
    {
    }

    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public enum Brand
    {
        Apple, Samsung, Ford
    }

    public class Product
    {
        public string Name;
        public Color color;
        public Size size;
        public Brand brand;

        public Product(string Name, Color color, Size size, Brand brand)
        {
            if (Name == null)
                throw new ArgumentNullException(paramName: nameof(Name));

            this.Name = Name;
            this.color = color;
            this.size = size;
            this.brand = brand;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.size == size)
                {
                    yield return p;
                }
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.color == color)
                {
                    yield return p;
                }
            }
        }

        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var p in products)
            {
                if (p.color == color && p.size == size)
                {
                    yield return p;
                }
            }
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisified(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisified(Product p)
        {
            return p.color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisified(Product p)
        {
            return p.size == size;
        }
    }

    public class BrandSpecification : ISpecification<Product>
    {
        private Brand brand;

        public BrandSpecification(Brand brand)
        {
            this.brand = brand;
        }

        public bool IsSatisified(Product t)
        {
            return t.brand == brand;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }
        public bool IsSatisified(T t)
        {
            return first.IsSatisified(t) && second.IsSatisified(t);
        }
    }

    public class MultiSpecification<T> : ISpecification<T>
    {
        private IList<ISpecification<T>> Filters;
        public MultiSpecification(IList<ISpecification<T>> filters)
        {
            Filters = filters ?? throw new ArgumentNullException(paramName: nameof(filters));
        }
        public bool IsSatisified(T t)
        {
            bool flag = true;
            foreach (var f in Filters)
            {                
                flag &= f.IsSatisified(t);
            }

            return flag;
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisified(i))
                    yield return i;
            }
        }
    }

    //static void Main(string[] args)
    //{
    //    var apple = new Product("Apple", Color.Green, Size.Small);
    //    var tree = new Product("Tree", Color.Green, Size.Large);
    //    var house = new Product("House", Color.Blue, Size.Large);

    //    Product[] products = { apple, tree, house };

    //    var pf = new ProductFilter();
    //    foreach (var p in pf.FilterByColor(products, Color.Green))
    //    {
    //        WriteLine($" - {p.Name} is Green");
    //    }

    //    foreach (var p in pf.FilterBySizeAndColor(products, Size.Small, Color.Green))
    //    {
    //        WriteLine($" - {p.Name} is Small and Green");
    //    }

    //    var bf = new BetterFilter();
    //    foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
    //    {
    //        WriteLine($" - {p.Name} is Green");
    //    }

    //    foreach (var p in bf.Filter(products, new AndSpecification<Product>(
    //        new ColorSpecification(Color.Blue),
    //        new SizeSpecification(Size.Large)
    //        )))
    //    {
    //        WriteLine($" - {p.Name} is Blue & Large");
    //    }

    //    ReadLine();
    //}
}

