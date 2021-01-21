using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    /// <summary>
    /// Klasa UmowyKupnay agreguje obiekty typu UmowaPosrednictwaKupna.
    /// </summary>
    [Serializable]
    public class UmowyKupna
    {
        List<UmowaPosrednictwaKupna> _listaUmow = new List<UmowaPosrednictwaKupna>();

        public List<UmowaPosrednictwaKupna> ListaUmow { get => _listaUmow; set => _listaUmow = value; }

        public UmowyKupna()
        {
        }

        /// <summary>
        /// Dodawanie obiektu UmowaPosrednictwaKupna do List<UmowaPosrednictwaKupna>
        /// </summary>
        /// <param name="u">
        /// Obiekt typu UmowaPosrednictwaKupna
        /// </param>
        public void DodajUmowe(UmowaPosrednictwaKupna u)
        {
            ListaUmow.Add(u);
        }

        /// <summary>
        /// Usuwanie obiektu UmowaPosrednictwaKupna z List<UmowaPosrednictwaKupna>
        /// </summary>
        /// <param name="numerUmowy">
        /// numer umowy
        /// </param>
        public void UsunUmowe(string numerUmowy)
        {
            foreach (UmowaPosrednictwaKupna u in ListaUmow)
            {
                if (u.NrUmowy == numerUmowy)
                {
                    ListaUmow.Remove(u);
                }
            }
        }
        /// <summary>
        /// Filtrowanie listy po wskazanwj dacie
        /// </summary>
        /// <param name="dataSzukana">
        /// Szukana data
        /// </param>
        /// <returns>
        /// Lista zawierajaca odfiltrowane obiekty typu UmowaPosrednictwaKupna
        /// </returns>
        public List<UmowaPosrednictwaKupna> filtrujDataZawarcia(string dataSzukana)
        {
            List<UmowaPosrednictwaKupna> _szukaneUmowy = new List<UmowaPosrednictwaKupna>();
            foreach (UmowaPosrednictwaKupna u in _listaUmow)
            {
                if (u.DataZawarcia.ToString("dd-MM-yyyy") == dataSzukana)
                {
                    _szukaneUmowy.Add(u);
                }
            }
            return _szukaneUmowy;
        }
        /// <summary>
        /// Filtrowanie listy po wskazanym argumencie PESEL nalezacym do pracownika.
        /// </summary>
        /// <param name="PESEL">
        /// PESEL pracownika 
        /// </param>
        /// <returns>
        /// Lista zawierajaca obiekty typu UmowaPosrednictwaKupna, ktorymi zajmuje sie dany pracownik.
        /// </returns>
        public List<UmowaPosrednictwaKupna> filtrujPracownik(string PESEL)
        {
            List<UmowaPosrednictwaKupna> _umowyPracownika = new List<UmowaPosrednictwaKupna>();
            foreach (UmowaPosrednictwaKupna u in _listaUmow)
            {
                if (u.OpiekunKlienta.PESEL == PESEL)
                {
                    _umowyPracownika.Add(u);
                }
            }
            return _umowyPracownika;
        }

        /// <summary>
        /// Serializacja do XML
        /// </summary>
        /// <param name="plik">
        /// Nazwa pliku, w ktorym chcemy zapisac dokument XML.
        /// </param>
        public void ZapiszXML(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UmowyKupna)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>
        /// Deserializacja dokumentu XML
        /// </summary>
        /// <param name="plik">
        /// Plik, z ktorego chcemy deserializowac XML.
        /// </param>
        /// <returns>
        /// Zdeserializowany obiekt
        /// </returns>
        public static UmowyKupna OdczytajXML(string plik)
        {
            if (!File.Exists(plik))
            {
                return null;
            }
            using (StreamReader reader = new StreamReader(plik))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UmowyKupna));
                return (UmowyKupna)serializer.Deserialize(reader);
            }
        }
    }
}
