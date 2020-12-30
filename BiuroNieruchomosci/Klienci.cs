using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    [Serializable]
    public class Klienci : Zbiorowosc
    {
        List<Klient> _listaKlientow = new List<Klient>();

        public Klienci() : base()
        {
            
        }

        public List<Klient> ListaKlientow { get => _listaKlientow; set => _listaKlientow = value; }

        public void ZapiszXML(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Klienci)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

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

        public void DodajKlienta(Klient k)
        {
            ListaKlientow.Add(k);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach(Osoba k in ListaKlientow)
            {
                s.AppendLine(k.ToString());
            }
            return s.ToString();
        }
    }
}
