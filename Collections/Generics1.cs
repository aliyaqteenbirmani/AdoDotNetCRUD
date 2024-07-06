using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.Collections
{
    class Generics2<T>
    {
        public void Add(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 + d2);
        }
        public void Sub(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 - d2);
        }
        public void Mul(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 * d2);
        }
        public void Div(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 / d2);
        }
 
    }
    class Generics1
    {
        public bool Compare(object a, object b)
        {
            if (a.Equals(b))
                return true;
            return false;
        }

        //static void Main(string[] args)
        //{
        //    //Generics1 obj = new Generics1();
        //    //bool result = obj.Compare(10, 10);
        //    //Console.WriteLine(result);

        //    Generics2<int> obj = new Generics2<int>();
        //    obj.Add(3, 4); obj.Sub(5, 2); obj.Mul(3, 4); obj.Div(3, 4);
        //}
    }
}
