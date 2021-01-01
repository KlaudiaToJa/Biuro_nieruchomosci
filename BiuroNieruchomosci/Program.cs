using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiuroNieruchomosci
{
    class Program
    {
        static void Main(string[] args)
        {
            Klienci lista = new Klienci();
            Klient k = new Klient("k", "d", "00000000000", "31-03-2000");
            lista.DodajKlienta(k);
            lista.ZapiszXML("listaKlientow.xml");
            Klienci nowa = new Klienci();
            nowa = Klienci.OdczytajXML("listaKlientow.xml");
            Console.WriteLine(nowa);
            Console.ReadLine();
        }
    }
}
