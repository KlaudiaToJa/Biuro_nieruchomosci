using System;
using System.Collections.Generic;
using System.Text;

namespace Biuro_nieruchomosci
{
    public class WszystkieNieruchomosci
    {
        List<Nieruchomosc> listaNieruchomosci;

        public WszystkieNieruchomosci()
        {
            listaNieruchomosci = new List<Nieruchomosc>();
        }

        public void DodajNieruchomosc(Nieruchomosc n)
        {
            listaNieruchomosci.Add(n);
        }

        public void UsunNieruchomosc(string idUsuwanej)
        {
            // znalezienie nieruchomosci z podanym id:
            int index = listaNieruchomosci.FindIndex(item => item.IdNieruchomosci == idUsuwanej);
            if (index >= 0) // jesli taki element istnieje
            {
                listaNieruchomosci.RemoveAt(index);
            }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (Nieruchomosc n in listaNieruchomosci)
            {
                s.AppendLine(n.ToString());
            }
            return s.ToString();
        }
    }
}
