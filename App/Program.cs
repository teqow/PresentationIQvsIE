using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new EFDbContext())
            {

                Console.WriteLine("Press Enter to start");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key.Equals(ConsoleKey.Enter))
                {
                    //IEnumerable where price > 400 and take 5 elements

                    Stopwatch sw = Stopwatch.StartNew();
                    IEnumerable<Product> ienumerable = context.Products.ToList().Where(p => p.Price > 400);
                    var result = ienumerable.Take(5).ToList();
                    TimeSpan elapsed = sw.Elapsed;
                    Console.WriteLine($"IEnumerable query where Price>400 and take 5 elements took: {elapsed.Milliseconds}");

                    //IQueryable where price > 400 and take 5 elements

                    Stopwatch sw1 = Stopwatch.StartNew();
                    IQueryable<Product> iqueryable = context.Products.Where(p => p.Price > 400);
                    var result1 = iqueryable.Take(5).ToList();
                    TimeSpan elapsed1 = sw1.Elapsed;
                    Console.WriteLine($"IQueryable query where Price>400 and take 5 elements took: {elapsed1.Milliseconds}");

                    Console.ReadKey();
                }
                Console.ReadKey();
            }
        }
    }
}
