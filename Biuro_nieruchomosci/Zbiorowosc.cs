using System;
using System.Collections.Generic;

namespace Biuro_nieruchomosci
{
    public class Zbiorowosc
    {
        List<Osoba> _listaOsob=new List<Osoba>();

        public Zbiorowosc()
        {

        }

        public List<Osoba> ListaOsob { get => _listaOsob; set => _listaOsob = value; }

        public void DodajOsobe (Osoba o)
        {
            ListaOsob.Add(o);
        }

        public void UsunOsobe (string pesel)
        {
            foreach (Osoba o in ListaOsob)
            {
                if (o.PESEL==pesel)
                {
                    ListaOsob.Remove(o);
                }
            }
        }




    }
}
