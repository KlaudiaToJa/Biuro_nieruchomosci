using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    [Serializable]
    public class UmowyKupna
    {
        List<UmowaPosrednictwaKupna> _listaUmow = new List<UmowaPosrednictwaKupna>();

        public List<UmowaPosrednictwaKupna> ListaUmow { get => _listaUmow; set => _listaUmow = value; }

        public UmowyKupna()
        {
        }

        public void DodajUmowe(UmowaPosrednictwaKupna u)
        {
            ListaUmow.Add(u);
        }

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

        public void ZapiszXML(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UmowyKupna)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

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
