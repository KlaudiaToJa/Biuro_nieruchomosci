﻿using System;
using System.Windows;
using Biuro_nieruchomosci;

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy OknoDodajKlienta.xaml
    /// </summary>
    public partial class OknoDodajKlienta : Window
    {
        Klient _klient;
        public OknoDodajKlienta()
        {
            InitializeComponent();
        }

        private void ButtonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonZatwierdz_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
