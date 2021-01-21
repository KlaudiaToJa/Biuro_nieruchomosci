using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;


/// <summary>
/// Klasa Klienci agreguje klientow (obiekty Klient). 
/// </summary>


namespace BiuroNieruchomosci
{
    [Serializable]
    public class Klienci
    {
        List<Klient> _listaKlientow = new List<Klient>();

        public Klienci() 
        {
            
        }

        public List<Klient> ListaKlientow { get => _listaKlientow; set => _listaKlientow = value; }

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
                XmlSerializer serializer = new XmlSerializer(typeof(Klienci)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>
        /// Deserializacja pliku XML
        /// </summary>
        /// <param name="plik">
        /// Plik, z ktorego chcemy deserializowac XML.
        /// </param>
        /// <returns>
        /// Zdeserializowany obiekt
        /// </returns>
        public static Klienci OdczytajXML(string plik)
        {
            if (!File.Exists(plik))
            {
                return null;
            }
            using (StreamReader reader = new StreamReader(plik))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Klienci));
                return (Klienci)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Dodowanie klienta z listy
        /// </summary>
        /// <param name="k">
        /// Obiekt typu klient
        /// </param>
        public void DodajKlienta(Klient k)
        {
            ListaKlientow.Add(k);
        }


       /// <summary>
       /// Usuwanie klienta z listy
       /// </summary>
       /// <param name="klient"></param>
        public void UsunKlienta(Klient klient)
        {
            foreach (Klient k in _listaKlientow)
            {
                if (k.Equals(klient))
                {
                    ListaKlientow.Remove(klient);
                    break;
                }
            }
        }

        /// <summary>
        /// Sprawdzanie po numerze PESEL czy Klient znajduje sie w bazie
        /// </summary>
        /// <param name="pesel">
        /// PESEL klienta
        /// </param>
        /// <returns>
        /// True jesli Klient znajduje sie w bazie, False w przeciwnym wypadku
        /// </returns>
        public bool CzyJestWBazie(string pesel)
        {
            foreach (Osoba k in ListaKlientow)
            {
                if (k.PESEL == pesel)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Czysci liste z obiektow.
        /// </summary>
        public void WyczyscListe()
        {
            ListaKlientow.Clear();
        }

        /// <summary>
        /// Sortuje alfabetycznie nazwiska klientow za pomoca metody CompareTo()
        /// </summary>
        public void SortujNazwiskaImiona()
        {
            ListaKlientow.Sort();
        }

        /// <summary>
        /// Sortuje alfabetycznie miejscowosci za pomoca Comparison: (x, y) => x.Miejscowosc.CompareTo(y.Miejscowosc))
        /// </summary>
        public void SortujMiejscowosciami()
        {
            ListaKlientow.Sort((x, y) => x.Miejscowosc.CompareTo(y.Miejscowosc));
        }
    }
}
