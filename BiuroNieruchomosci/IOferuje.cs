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

        List<Oferta> filtrujImieKlienta(string imie);

        List<Oferta> filtrujNazwiskoKlienta(string nazwisko);

        List<Oferta> filtrujDate(string data);

        List<Oferta> filtrujImieOpiekuna(string imie);

        List<Oferta> filtrujNazwiskoOpiekuna(string nazwisko);

        List<Oferta> PrzegladajOferty(bool czyAktywna);
    }
}
