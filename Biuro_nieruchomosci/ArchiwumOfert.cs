using System;
using System.Collections.Generic;

namespace Biuro_nieruchomosci
{
    public class ArchiwumOfert
    {
        List<Oferta> _listaOfertArchiwum;

        public ArchiwumOfert()
        {

        }

        public void DodajArchiwum (Oferta o)
        {
            ListaOfertArchiwum.Add(o);
        }

        public void UsunArchiwum (string idOferty)
        {
            foreach (Oferta o in ListaOfertArchiwum)
            {
                if (o.IdOferty==idOferty)
                {
                    ListaOfertArchiwum.Remove(o);
                }
            }
        }

        public List<Oferta> ListaOfertArchiwum { get => _listaOfertArchiwum; set => _listaOfertArchiwum = value; }
    }
}
