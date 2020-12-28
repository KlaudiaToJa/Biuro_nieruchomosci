using System;
using System.Collections.Generic;

namespace Biuro_nieruchomosci
{
    public class Klienci:Zbiorowosc
    {
        List<Klient> _listaKlientow = new List<Klient>();

        public Klienci()
        {

        }

        public List<Klient> ListaKlientow { get => _listaKlientow; set => _listaKlientow = value; }

        public bool CzyJestWBazie (string pesel)
        {
            foreach (Klient k in ListaKlientow)
            {
                if (k.PESEL==pesel)
                {
                    Console.WriteLine("Taki klient jest w bazie");
                    return true;
                }
            }
            return false;
        }
    }
}
