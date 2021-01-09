using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BiuroNieruchomosci
{
    [Serializable]
    public class Pracownicy : Zbiorowosc
    {
        List<Pracownik> _listaPracownikow = new List<Pracownik>();

        public Pracownicy()
        {

        }

        public void ZapiszXML(string plik)
        {
            using (StreamWriter writer = new StreamWriter(plik)) //otwieramy strumien
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pracownicy)); //tworzymy serializator xml
                serializer.Serialize(writer, this);
            }
        }

        public static Pracownicy OdczytajXML(string plik)
        {
            if (!File.Exists(plik))
            {
                return null;
            }
            using (StreamReader reader = new StreamReader(plik))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pracownicy));
                return (Pracownicy)serializer.Deserialize(reader);
            }
        }
    }
}
