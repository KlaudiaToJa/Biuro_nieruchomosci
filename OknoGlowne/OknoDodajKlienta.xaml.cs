﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OknoGlowne
{
    /// <summary>
    /// Logika interakcji dla klasy OknoDodajKlienta.xaml
    /// </summary>
    public partial class OknoDodajKlienta : Window
    {
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
