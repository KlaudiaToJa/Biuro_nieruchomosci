using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiuroNieruchomosci
{
    interface IOferuje
    {
        void DodajOferte(Oferta o);
        void UsunOferte(string idOferty);
    }
}
