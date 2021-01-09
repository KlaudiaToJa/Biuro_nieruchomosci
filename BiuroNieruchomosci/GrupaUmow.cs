using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


// DO POPRAWIENIA


namespace BiuroNieruchomosci
{
    [Serializable]
    public abstract class GrupaUmow
    {
        List<Umowa> _listaUmow;

        public GrupaUmow()
        {

        }

        public void DodajUmowe(Umowa u)
        {
            ListaUmow.Add(u);
        }

        /*public void UsunUmowe (string numerUmowy)
        {
            foreach (Umowa u in ListaUmow)
            {
                
            }
        }*/

        /*public void ArchiwizujUmowe (string numerUmowy)
        {

        }*/

        public List<Umowa> UmowyDataZawarcia(string dataSzukana)
        {
            List<Umowa> _szukaneUmowy = new List<Umowa>();
            foreach (Umowa u in _listaUmow)
            {
                if (u.DataZawarcia.ToString("dd-MM-yyyy") == dataSzukana)
                {
                    _szukaneUmowy.Add(u);
                }
            }
            return _szukaneUmowy;
        }

        public List<Umowa> UmowyPracownika(string PESEL)
        {
            List<Umowa> _umowyPracownika = new List<Umowa>();
            foreach (Umowa u in _listaUmow)
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
                XmlSerializer serializer = new XmlSerializer(typeof(GrupaUmow)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

        public static GrupaUmow OdczytajXML(string plik)
        {
            if (!File.Exists(plik))
            {
                return null;
            }
            using (StreamReader reader = new StreamReader(plik))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(GrupaUmow));
                return (GrupaUmow)serializer.Deserialize(reader);
            }
        }

        public List<Umowa> ListaUmow { get => _listaUmow; set => _listaUmow = value; }
    }
}
