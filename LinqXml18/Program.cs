using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqXml18
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "input.xml";
            XDocument d = XDocument.Load(input);
            foreach (XElement sample in d.Descendants())
            {
            }
            IEnumerable<XName> unique = from n in d.Descendants().Attributes()
                         group n by n.Name into nGroup
                         orderby nGroup.Key.LocalName
                         select nGroup.Key;
            foreach (XName x in unique)
            {
                Console.WriteLine("Атрибут:");
                Console.WriteLine(x);
                var a = d.Descendants().Attributes()
                 .Where(e => e.Name == x)
                  .Select(e => e.Value);
                Console.WriteLine("Значения атрибута:");
                foreach (string atr in a)
                {
                    Console.WriteLine(atr);
                }
                Console.WriteLine();
            }
            Process.Start(input);
            Console.ReadKey();
        }
    }
}
