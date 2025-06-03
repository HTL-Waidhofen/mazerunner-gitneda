using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
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
        public double posX = 1;
        public double posY = 1;


        public double FlaecheBerechnen()
        {


            return laenge * breite;
        }

        public Rechteck(double laenge, double breite, double posX, double posY)

        {
            this.laenge = laenge;
            this.breite = breite;
            this.posX = posX;
            this.posY = posY;
        }

        public override string ToString()
        {
            return $"Rechteck: {laenge}x{breite}";
        }

    }

    class Spieler
    {
        public int x;
        public int y;
        public Image image;

        public Spieler()
        {
            x = 1;
            y = 1;
        }

        public void Move(Key key)
        {
            if (key == Key.Left)
            {
                x--;
            }
            else if (key == Key.Right)
            {
                x++;
            }
            else if (key == Key.Up)
            {
                y--;

            }
            else if (key == Key.Down)
            {
                y++;
            }

            Canvas.SetTop(image, y * MainWindow.GRID_SIZE);
            Canvas.SetLeft(image, x * MainWindow.GRID_SIZE);
        }

    }

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Rechteck> rechtecke = new List<Rechteck>();
        Spieler spieler = new Spieler();
        public static int GRID_SIZE = 10;



        public MainWindow()
        {
            InitializeComponent();
            StreamReader reader = new StreamReader("wallsList.txt");
            string zeile;
            double laenge = 10;
            double breite = 10;
            double posX = 0;
            double posY = 0;

            while ((zeile = reader.ReadLine()) != null)
            {
                string[] teile = zeile.Split(',');
                posX = double.Parse(teile[0]) * GRID_SIZE;
                posY = double.Parse(teile[1]) * GRID_SIZE;





                if (lstRechtecke.SelectedItem != null)
                {
                    Rechteck r = (Rechteck)lstRechtecke.SelectedItem;
                    r.laenge = laenge;
                    r.breite = breite;


                }
                else
                {
                    Rechteck r = new Rechteck(1, 1, posX, posY);
                    lstRechtecke.Items.Add(r);
                    rechtecke.Add(r);
                }
                Rectangle rect = new Rectangle();

                rect.Width = laenge;
                rect.Height = breite;
                rect.StrokeThickness = 2;
                rect.Stroke = Brushes.Black;
                rect.Fill = Brushes.Black;

                Canvas.SetLeft(rect, posX);
                Canvas.SetTop(rect, posY);


                myCanvas.Children.Add(rect);
            }

            reader.Close();
            spieler.image = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("Unbenannt.png", UriKind.Relative);
            bitmap.EndInit();
            spieler.image.Source = bitmap;
            spieler.image.Width = GRID_SIZE;
            spieler.image.Height = GRID_SIZE;
            Canvas.SetTop(spieler.image, spieler.y * GRID_SIZE);
            Canvas.SetLeft(spieler.image, spieler.x * GRID_SIZE);
            myCanvas.Children.Add(spieler.image);

        }
        private void lstRechtecke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rechteck r = (Rechteck)this.lstRechtecke.SelectedItem;
            if (r != null)
            {
                tbxLaenge.Text = r.laenge.ToString();
                tbxBreite.Text = r.breite.ToString();
                tbxx.Text = r.posX.ToString();
                tbxy.Text = r.posY.ToString();
            }
        }

        private void Button_Zeichnen_Click(object sender, RoutedEventArgs e)
        {
            string laengeStr = this.tbxLaenge.Text;
            double laenge = double.Parse(laengeStr);
            string breiteStr = this.tbxBreite.Text;
            double breite = double.Parse(breiteStr);
            string posXStr = this.tbxx.Text;
            double posX = double.Parse(tbxx.Text);
            string posYStr = this.tbxy.Text;
            double posY = double.Parse(tbxy.Text);
            Rectangle rect = new Rectangle();

            rect.Width = laenge;
            rect.Height = breite;
            rect.StrokeThickness = 2;
            rect.Stroke = Brushes.Black;

            Canvas.SetLeft(rect, posX);
            Canvas.SetTop(rect, posY);


            myCanvas.Children.Add(rect);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string laengeStr = this.tbxLaenge.Text;
                double laenge = double.Parse(laengeStr);
                string breiteStr = this.tbxBreite.Text;
                double breite = double.Parse(breiteStr);
                double posX = double.Parse(tbxx.Text);
                double posY = double.Parse(tbxy.Text);

                if (lstRechtecke.SelectedItem != null)
                {
                    Rechteck r = (Rechteck)lstRechtecke.SelectedItem;
                    r.laenge = laenge;
                    r.breite = breite;


                }
                else
                {
                    Rechteck r = new Rechteck(laenge, breite, posX, posY);
                    lstRechtecke.Items.Add(r);
                    rechtecke.Add(r);
                }

                tbxLaenge.Clear();
                tbxBreite.Clear();
                tbxx.Clear();
                tbxy.Clear();
                lstRechtecke.SelectedItem = null;

                lstRechtecke.Items.Refresh();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ungültige Eingabe!");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            spieler.Move(e.Key);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            stp_sidebar.Visibility = Visibility.Collapsed;
        }
    }
}