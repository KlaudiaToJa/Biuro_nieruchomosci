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
            Klient k = new Klient();
            lista.DodajKlienta(k);
            lista.ZapiszXML("listaKlientow.xml");
            Klienci nowa = new Klienci();
            nowa = Klienci.OdczytajXML("listaKlientow.xml");
            Console.WriteLine(nowa);
            Console.ReadLine();
        }
    }
}
