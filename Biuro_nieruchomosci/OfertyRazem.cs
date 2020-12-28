using System;
using System.Collections.Generic;

namespace Biuro_nieruchomosci
{
    public class OfertyRazem:ArchiwumOfert
    {
        List<Oferta> _listaOfert;

        public OfertyRazem()
        {

        }

        public void DodajOferte(Oferta o)
        {
            ListaOfert.Add(o);
        }

        public void UsunOferte (string idOferty)
        {
            foreach (Oferta o in ListaOfert)
            {
                if (o.IdOferty==idOferty)
                {
                    ListaOfert.Remove(o);
                }
            }
        }

        public void ArchiwizujOferte (string idOferty)
        {
            foreach (Oferta o in ListaOfert)
            {
                if (o.IdOferty==idOferty)
                {
                    DodajArchiwum(o);
                }
            }
        }

        public List<Oferta> ListaOfert { get => _listaOfert; set => _listaOfert = value; }
    }
}
