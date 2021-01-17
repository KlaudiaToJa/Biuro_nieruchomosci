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

        List<Oferta> filtrujImieKlienta(string imie, bool czyAktywna);

        List<Oferta> filtrujNazwiskoKlienta(string nazwisko, bool czyAktywna);

        List<Oferta> filtrujDate(string data, bool czyAktywna);

        List<Oferta> filtrujImieOpiekuna(string imie, bool czyAktywna);

        List<Oferta> filtrujNazwiskoOpiekuna(string nazwisko, bool czyAktywna);

        List<Oferta> PrzegladajOferty(bool czyAktywna);
    }
}
