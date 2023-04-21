using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VláknaCvičení
{
    internal class Kovarna
    {
        private int maxZeleza;
        private int aktualniZelezo;
        private int zelezoNaBrneni;
        private int zelezoNaMec;
        private object zamek = new object();

        public Kovarna(int maxZeleza, int aktualniZelezo, int zelezoNaBrneni, int zelezoNaMec)
        {
            this.maxZeleza = maxZeleza;
            this.aktualniZelezo = aktualniZelezo;
            this.zelezoNaBrneni = zelezoNaBrneni;
            this.zelezoNaMec = zelezoNaMec;
        }

        public bool odeberZelezo(int mnozstvi)
        {
            lock (zamek)
            {
                if (mnozstvi > aktualniZelezo)
                {
                    Console.WriteLine("Odebirane mnozstvi: " + mnozstvi + " Nepodarilo se odebrat mnozstvi.");
                    return false;   
                }
                aktualniZelezo -= mnozstvi;
                Console.WriteLine("Odebrane Mnozstvi: " + mnozstvi + " Podarilo se odebrat mnozstvi.");
                return true;    
            }
        }

        public bool pridejZelezo(int mnozstvi)
        {
            lock (zamek)
            {
                int noveMnozstvi = aktualniZelezo + mnozstvi;
                if (noveMnozstvi > maxZeleza)
                {
                    Console.WriteLine("Mnozstvi: " + mnozstvi + " Nepridano. Sklad je plny. Na skladu je " + aktualniZelezo);
                    return false;
                }
                aktualniZelezo = noveMnozstvi;
                Console.WriteLine("Mnozstvi: " + mnozstvi + " Pridano. Na skladu je " + aktualniZelezo);
                return true;    
            }
        }

        public int vyrobMec(int mnozstviMec)
        {
            int mnozstviZeleza = mnozstviMec * zelezoNaMec;
            if (odeberZelezo(mnozstviZeleza))
            {
                Console.WriteLine("Na vyrobu " + mnozstviMec + " mecu bylo zpotrebovano " + mnozstviZeleza + " zeleza.");
                return mnozstviMec;
            }
            Console.WriteLine("Na vyrobu " + mnozstviMec + " mecu nebylo dostatek " + mnozstviZeleza + " zeleza.");
            return 0;
        }

        public int vyrobBrneni(int mnozstviBrneni)
        {
            int mnozstviZeleza = mnozstviBrneni * zelezoNaBrneni;
            if (odeberZelezo(mnozstviZeleza))
            {
                Console.WriteLine("Na vyrobu " + mnozstviBrneni + " brneni bylo zpotrebovano " + mnozstviZeleza + " zeleza.");
                return mnozstviBrneni;
            }
            Console.WriteLine("Na vyrobu " + mnozstviBrneni + " brneni nebylo zpotrebovano " + mnozstviZeleza + " zeleza.");
            return 0;
        }
    }
}
