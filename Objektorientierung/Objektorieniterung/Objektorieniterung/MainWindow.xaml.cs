using System;
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

namespace Objektorieniterung
{
    class Rechteck
    {
        public double laenge = 1;
        public double breite = 2;

        public double FlaecheBerechnen()
        {


            return laenge * breite;
        }

        public Rechteck(double laenge, double breite)

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
                string laengeStr = this.tbxLaenge.Text;
                double laenge = double.Parse(laengeStr);
                string breiteStr = this.tbxBreite.Text;
                double breite = double.Parse(breiteStr);

                if (lstRechtecke.SelectedItem != null)
                {
                    Rechteck r = (Rechteck)lstRechtecke.SelectedItem;
                    r.laenge = laenge;
                    r.breite = breite;


                }
                else
                {
                    Rechteck r = new Rechteck(laenge, breite);
                    lstRechtecke.Items.Add(r);
                    rechtecke.Add(r);
                }

                tbxLaenge.Clear();
                tbxBreite.Clear();
                lstRechtecke.SelectedItem = null;

                Rectangle rect = new Rectangle();
                rect.Width = laenge;
                rect.Height = breite;
                rect.StrokeThickness = 2;
                rect.Stroke = Brushes.Black;
                myCanvas.Children.Add(rect);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ungültige Eingabe!");
            }
        }


        private void lstRechtecke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rechteck r = (Rechteck)this.lstRechtecke.SelectedItem;

            tbxLaenge.Text = r.laenge.ToString();
            tbxBreite.Text = r.breite.ToString();

        }
    }
}