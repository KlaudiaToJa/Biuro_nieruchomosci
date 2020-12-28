using System;
using System.Collections.Generic;

namespace Biuro_nieruchomosci
{
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

        public List<Umowa> UmowyDataZawarcia (string dataSzukana)
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

        public List <Umowa> UmowyPracownika (string PESEL)
        {
            List<Umowa> _umowyPracownika = new List<Umowa>();
            foreach (Umowa u in _listaUmow)
            {
                if (u.OpiekunKlienta.PESEL==PESEL)
                {
                    _umowyPracownika.Add(u);
                }
            }
            return _umowyPracownika;
        }

        public List<Umowa> ListaUmow { get => _listaUmow; set => _listaUmow = value; }
    }
}
