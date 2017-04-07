using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //using(NorthwindContext db=new NorthwindContext())
            //{
            //    var bestellungen = db.Bestellungen.Where(x => x.OrderID > 500);
            //}

            using (NorthwindContext db = new NorthwindContext())
            {
                var orders = db.Orders
                    .Take(20)
                    .OrderBy(x => x.ShipName);
                
                StringBuilder build = new StringBuilder();

                foreach (var item in orders)
                {
                    build.AppendFormat("{0}: {1}, {2} {3}, {4}\n", item.ShipName, item.ShipAddress, item.ShipPostalCode, item.ShipCity, item.ShipCountry);
                    Console.WriteLine(build.ToString());
                    build.Clear();
                }

            }
            Console.ReadKey();
        }
    }
}
