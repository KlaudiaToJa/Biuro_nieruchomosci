using System;
using System.Globalization;

namespace BiuroNieruchomosci
{
    /// <summary>
    /// Klasa abstrakcyjna Umowa, ktora tworzy wzor dla innych klas, wykorzystujacych te same atrybuty i metody: UmowaPosrednictwaKupna, UmowaPosrednictwaSprzedazy.
    /// Nie można utworzyć instancji klasy abstrakcyjnej. Celem klasy abstrakcyjnej jest zapewnienie wspólnej definicji klasy bazowej, 
    /// która może być współużytkowana przez wiele klas pochodnych.
    /// </summary>
    [Serializable]
    public abstract class Umowa
    {
        Pracownik _opiekunKlienta;
        double _prowizja;
        DateTime _dataZawarcia;
        DateTime _dataZakonczenia;

        public Umowa()
        {
            OpiekunKlienta = null;
            Prowizja = 0;
            DataZawarcia = DateTime.Now;
            DataZakonczenia = DateTime.Now;

        }

        public Umowa(Pracownik opiekunKlienta, double prowizja, string dataZawarcia, string dataZakonczenia) : this()
        {
            OpiekunKlienta = opiekunKlienta;
            Prowizja = prowizja;
            DateTime.TryParseExact(dataZawarcia, new[] { "dd-MM-yyyy" }, null, DateTimeStyles.None, out _dataZawarcia);
            DateTime.TryParseExact(dataZakonczenia, new[] { "dd-MM-yyyy" }, null, DateTimeStyles.None, out _dataZakonczenia);
        }

        public override string ToString()
        {
            return $"Pracownik: {OpiekunKlienta}, prowizja: {Prowizja}, {DataZawarcia.ToString("dd-MM-yyyy")}-{DataZakonczenia.ToString("dd-MM-yyyy")}";
        }

        public Pracownik OpiekunKlienta { get => _opiekunKlienta; set => _opiekunKlienta = value; }
        public double Prowizja { get => _prowizja; set => _prowizja = value; }
        public DateTime DataZawarcia { get => _dataZawarcia; set => _dataZawarcia = value; }
        public DateTime DataZakonczenia { get => _dataZakonczenia; set => _dataZakonczenia = value; }
    }
}
