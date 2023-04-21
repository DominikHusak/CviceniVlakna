using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VláknaCvičení
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kovarna kovarna = new Kovarna(20, 0, 4, 2);
            /*Console.WriteLine(kovarna.pridejZelezo(30));
            Console.WriteLine(kovarna.vyrobMec(10));
            Console.WriteLine(kovarna.pridejZelezo(10));
            Console.WriteLine(kovarna.vyrobMec(10));
            Console.WriteLine(kovarna.vyrobMec(4));*/

            int pocetMecu = 0;
            int pocetBrneni = 0;

            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    kovarna.pridejZelezo(4);
                    Thread.Sleep(100);
                }
            });

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 8; i++)
                {
                    pocetMecu += kovarna.vyrobMec(1);
                    Thread.Sleep(100);
                }
            });

            Thread thread3 = new Thread(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    pocetBrneni += kovarna.vyrobBrneni(1);

                }
            });


            thread1.Start();
            thread2.Start();  
            thread3.Start();
            thread1.Join(); 
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Mecu bylo vyrobeno " + pocetMecu);
            Console.WriteLine("Brneni bylo vyrobeno " + pocetBrneni);
        }
    }
}
