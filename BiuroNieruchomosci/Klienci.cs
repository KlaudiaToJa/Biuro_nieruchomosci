using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    [Serializable]
    public class Klienci : Zbiorowosc
    {
        List<Klient> _listaKlientow = new List<Klient>();

        public Klienci()
        {

        }

        public List<Klient> ListaKlientow { get => _listaKlientow; set => _listaKlientow = value; }

        public bool CzyJestWBazie(string pesel)
        {
            foreach (Klient k in ListaKlientow)
            {
                if (k.PESEL == pesel)
                {
                    return true;
                }
            }
            return false;
        }

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
    }
}
