using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiuroNieruchomosci
{/// <summary>
/// Interfejs definiuje tzw. "kontrakt". Wszystkie klasy, które implementują ten kontrakt, 
/// muszą zapewnić implementację elementów członkowskich zdefiniowanych w interfejsie. 
/// Ten interfejs zawiera metody, ktore musza zostac zaimplementowane w klasie OfertyRazem.
/// </summary>
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
