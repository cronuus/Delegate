using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExtensions
{
    public static class Extentions
    {
        public static T _First<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");
            foreach (T element in source)
            {
                if (predicate(element)) return element;
            }
            throw new Exception("Error");
        }
        public static T _Last<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");
            T result = default(T);
            bool found = false;
            foreach (T element in source)
            {
                if (predicate(element))
                {
                    result = element;
                    found = true;
                }
            }
            if (found) return result;
            throw new Exception("Error");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------sum
            Op sum = (a, b) => a + b;
            Op min = (a, b) => a - b;
            var res = sum(14, 12);
            var res1 = sum(12, 14);
            //----------------Message
            Message mes = message => Console.WriteLine(message);
            mes("Hi");
            //-------------Extensions
            var list = new List<string> ();
            list.Add("djighd");
            list.Add("ldha");
            list.Add("dfkqaoi");
            list.Add("jhfs");
            var res2 = list._First(x => x.Contains("f"));
            Console.WriteLine(res2);
            var res3 = list._Last(x => x.Contains("f"));
            Console.WriteLine(res3);
        }
    }
    public delegate int Op(int f, int s);
    public delegate void Message(string message);
}
