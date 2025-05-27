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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Objektorientierung
{
    class Rechteck
    {
        public double laenge = 1;
        public double breite = 2;

        public double FlaecheBerechnen(double laenge, double breite)
        { 
            return laenge*breite;
        }
        public Rechteck (double laenge, double breite)
        {
            this.laenge = laenge;
            this.breite = breite;
        }
        public override string ToString()
        {
            return $"Rechteck: {laenge}x{breite}";
        }
    }

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Rechteck> rechtecke = new List<Rechteck>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                string laengeStr = this.tbxHoehe.Text;
                double laenge = double.Parse(laengeStr);
                string breiteStr = this.tbxBreite.Text;
                double breite = double.Parse(breiteStr);
                Rechteck r = new Rechteck(laenge, breite);
                lstRechteck.Items.Add(r);
                rechtecke.Add(r);
                tbxHoehe.Clear();
                tbxBreite.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ungültige Eingabe!");
            }
            
        }
        private void lstRechtecke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rechteck r = (Rechteck)this.lstRechteck.SelectedItem;
            tbxHoehe.Text = r.laenge.ToString();
            tbxBreite.Text = r.breite.ToString();
        }

    }
}
