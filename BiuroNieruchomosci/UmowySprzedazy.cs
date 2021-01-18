using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    [Serializable]
    public class UmowySprzedazy 
    {
        List<UmowaPosrednictwaSprzedazy> _listaUmow = new List<UmowaPosrednictwaSprzedazy>();

        public List<UmowaPosrednictwaSprzedazy> ListaUmow { get => _listaUmow; set => _listaUmow = value; }

        public UmowySprzedazy()
        {
        }

        public void DodajUmowe(UmowaPosrednictwaSprzedazy u)
        {
            ListaUmow.Add(u);
        }

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

        public void ZapiszXML(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UmowySprzedazy)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

        public static UmowySprzedazy OdczytajXML(string plik)
        {
            if (!File.Exists(plik))
            {
                return null;
            }
            using (StreamReader reader = new StreamReader(plik))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UmowySprzedazy));
                return (UmowySprzedazy)serializer.Deserialize(reader);
            }
        }
    }
}
