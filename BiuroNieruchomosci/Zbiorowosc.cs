using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    [Serializable]
    public class Zbiorowosc
    {
        List<Osoba> _listaOsob = new List<Osoba>();

        public Zbiorowosc()
        {

        }

        public List<Osoba> ListaOsob { get => _listaOsob; set => _listaOsob = value; }

        public void DodajOsobe(Osoba o)
        {
            ListaOsob.Add(o);
        }

        public void UsunOsobe(string pesel)
        {
            foreach (Osoba o in ListaOsob)
            {
                if (o.PESEL == pesel)
                {
                    ListaOsob.Remove(o);
                }
            }
        }

        public bool CzyJestWBazie(string pesel)
        {
            foreach (Osoba k in _listaOsob)
            {
                if (k.PESEL == pesel)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
