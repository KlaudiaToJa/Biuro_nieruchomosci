using System;
using System.Globalization;
using System.Text.RegularExpressions;



namespace BiuroNieruchomosci
{
    /// <summary>
    /// Klasa abstrakcyjna Osoba, ktora tworzy wzor dla innych klas, wykorzystujacych te same atrybuty: Klient, Pracownik.
    /// Nie można utworzyć instancji klasy abstrakcyjnej. Celem klasy abstrakcyjnej jest zapewnienie wspólnej definicji klasy bazowej, 
    /// która może być współużytkowana przez wiele klas pochodnych.
    /// </summary>
    [Serializable]
    public abstract class Osoba
    {
        string _imie;
        string _nazwisko;
        DateTime _dataUrodzenia;
        string _PESEL;
        string _miejscowosc;
        string _ulica;
        string _numerDomu;
        string _numerMieszkania;
        string _email;
        string _nrTelefonu;


        public string Imie { get => _imie; set => _imie = value; }
        public string Nazwisko { get => _nazwisko; set => _nazwisko = value; }
        public DateTime DataUrodzenia { get => _dataUrodzenia; set => _dataUrodzenia = value; }

        /// <summary>
        /// Zastosowanie wyrazenia regularnego sprawdzajacego poprawnosc adresu email w setterze Email.
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                Regex wzorzec2 = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
                if (wzorzec2.IsMatch(value))
                {
                    _email = value;
                }
                //else throw new FormatException();
            }
        }

        public string Miejscowosc { get => _miejscowosc; set => _miejscowosc = value; }
        public string Ulica { get => _ulica; set => _ulica = value; }
        public string NumerDomu { get => _numerDomu; set => _numerDomu = value; }
        public string NumerMieszkania { get => _numerMieszkania; set => _numerMieszkania = value; }
        
        /// <summary>
        /// Zastosowanie wyrazenia regularnego sprawdzajacego poprawnosc numeru telefonu w setterze Telefon.
        /// </summary>
        public string NrTelefonu 
        { 
            get => _nrTelefonu;
            set
            {
                Regex wzorzec = new Regex(@"^\d{9}$");
                if (wzorzec.IsMatch(value))
                {
                    _nrTelefonu = value;
                }
                //else throw new FormatException();
            }
        }
        public string PESEL { get => _PESEL; set => _PESEL = value; }

        public Osoba()
        {
            Imie = string.Empty;
            Nazwisko = string.Empty;
            PESEL = new string('0', 11);
            Miejscowosc = string.Empty;
            Ulica = string.Empty;
            NumerDomu = string.Empty;
            NumerMieszkania = string.Empty;
            Email = string.Empty;
            NrTelefonu = new string('0', 9);
        }

        public Osoba(string imie, string nazwisko, string dataUrodzenia, string Pesel) : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
            PESEL = Pesel;
            DateTime.TryParseExact(dataUrodzenia, new[] { "dd-MM-yyyy" }, null, DateTimeStyles.None, out _dataUrodzenia);
        }

        public Osoba(string imie, string nazwisko, string pesel, string dataUrodzenia, string miejscowosc, string numerdomu, string email, string nrtelefonu) : this(imie, nazwisko, dataUrodzenia, pesel)
        {
            Miejscowosc = miejscowosc;
            NumerDomu = numerdomu;
            Email = email;
            NrTelefonu = nrtelefonu;
        }

        public Osoba(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu) : this(imie, nazwisko, dataurodzenia, pesel, miejscowosc, numerdomu, email, nrtelefonu)
        {
            Ulica = ulica;
        }

        public Osoba(string imie, string nazwisko, string dataurodzenia, string pesel, string miejscowosc, string ulica, string numerdomu, string email, string nrtelefonu, string numermieszkania) : this(imie, nazwisko, dataurodzenia, pesel, miejscowosc, ulica, numerdomu, email, nrtelefonu)
        {
            NumerMieszkania = numermieszkania;
        }

    }
}
