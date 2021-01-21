using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    /// <summary>
    /// Klasa UmowySprzedazy agreguje obiekty typu UmowaPosrednictwaSprzedazy.
    /// </summary>
    [Serializable]
    public class UmowySprzedazy 
    {
        List<UmowaPosrednictwaSprzedazy> _listaUmow = new List<UmowaPosrednictwaSprzedazy>();

        public List<UmowaPosrednictwaSprzedazy> ListaUmow { get => _listaUmow; set => _listaUmow = value; }

        public UmowySprzedazy()
        {
        }


        /// <summary>
        /// Dodawanie obiektu typu UmowaPosrednictwaSprzedazy do listy
        /// </summary>
        /// <param name="u">
        /// Obiekt typu UmowaPosrednictwaSprzedazy
        /// </param>
        public void DodajUmowe(UmowaPosrednictwaSprzedazy u)
        {
            ListaUmow.Add(u);
        }


       /// <summary>
       /// Usuwanie obiektu typu o podanym w argumencie numerze umowy
       /// </summary>
       /// <param name="numerUmowy">
       /// Numer umowy
       /// </param>
        public void UsunUmowe (string numerUmowy)
        {
            foreach (UmowaPosrednictwaSprzedazy u in ListaUmow)
            {
                if(u.NumerUmowy == numerUmowy)
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
        /// Lista zawierajaca odfiltrowane obiekty typu UmowaPosrednictwaSprzedazy
        /// </returns>
        public List<UmowaPosrednictwaSprzedazy> filtrujDataZawarcia(string dataSzukana)
        {
            List<UmowaPosrednictwaSprzedazy> _szukaneUmowy = new List<UmowaPosrednictwaSprzedazy>();
            foreach (UmowaPosrednictwaSprzedazy u in _listaUmow)
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
        /// Lista zawierajaca obiekty typu UmowaPosrednictwaSprzedazy, ktorymi zajmuje sie dany pracownik.
        /// </returns>
        public List<UmowaPosrednictwaSprzedazy> filtrujPracownik(string PESEL)
        {
            List<UmowaPosrednictwaSprzedazy> _umowyPracownika = new List<UmowaPosrednictwaSprzedazy>();
            foreach (UmowaPosrednictwaSprzedazy u in _listaUmow)
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
                XmlSerializer serializer = new XmlSerializer(typeof(UmowySprzedazy)); //tworzymy serializator xml
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
        public static UmowySprzedazy OdczytajXML(string plik)
        {
            if (File.Exists(plik))
            {
                UmowySprzedazy umowySprzedazy = new UmowySprzedazy();
                using (StreamReader reader = new StreamReader(plik))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(UmowySprzedazy));
                    umowySprzedazy =  (UmowySprzedazy)serializer.Deserialize(reader);
                    if (!umowySprzedazy.ListaUmow.Count.Equals(0))
                    {
                        int liczba_znakow = umowySprzedazy.ListaUmow[umowySprzedazy.ListaUmow.Count - 1].NumerUmowy.IndexOf("/");
                        string id_ostatnie = umowySprzedazy.ListaUmow[umowySprzedazy.ListaUmow.Count - 1].NumerUmowy.Substring(0, liczba_znakow);
                        int numer_pom;
                        int.TryParse(id_ostatnie, out numer_pom);
                        UmowaPosrednictwaSprzedazy.Numer = numer_pom;
                    }
                    return umowySprzedazy;
                }
            }
            return null;
        }
    }
}
