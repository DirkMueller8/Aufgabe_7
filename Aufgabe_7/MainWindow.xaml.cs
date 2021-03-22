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
using System.Windows.Threading;

namespace Aufgabe_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int boarderRectangle;
        int remainingTime;
        int points;
        DispatcherTimer timerSpielzeit;
        public MainWindow()
        {
            InitializeComponent();
            boarderRectangle = 25;
            remainingTime = 120;
            points = 0;
            timerSpielzeit = new DispatcherTimer();
            //das Intervall setzen
            timerSpielzeit.Interval = TimeSpan.FromMilliseconds(1000);
            //die Methode für das Ereignis zuweisen
            timerSpielzeit.Tick += new EventHandler(Timer_Spielzeit);
            timerSpielzeit.Start();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ZeichneSpielfeld();
            //timerSpielzeit = new DispatcherTimer();
            ////das Intervall setzen
            //timerSpielzeit.Interval = TimeSpan.FromMilliseconds(1000);
            ////die Methode für das Ereignis zuweisen
            //timerSpielzeit.Tick += new EventHandler(Timer_Spielzeit);
            //Duration duration = newDuration(TimeSpan.FromSeconds(20));
            //DoubleAnimation doubleanimation = newDoubleAnimation(200.0, duration);
            //PBar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
            zeitAnzeige.Content = remainingTime;
            punktAnzeige.Content = points;
        }
        void ZeichneSpielfeld()
        {
            //der Balken oben
            ZeichneRechteck(new Point(0, 0), spielfeld.ActualWidth, boarderRectangle);
            //der Balken rechts
            ZeichneRechteck(new Point(spielfeld.ActualWidth - boarderRectangle, 0), boarderRectangle, spielfeld.ActualHeight);
            //der Balken unten
            ZeichneRechteck(new Point(0, spielfeld.ActualHeight - boarderRectangle), spielfeld.ActualWidth, boarderRectangle);
            //und der Balken links
            ZeichneRechteck(new Point(0, 0), boarderRectangle, spielfeld.ActualHeight);
        }
        void ZeichneRechteck(Point position, double laenge, double breite)
        {
            //einen neuen Balken erzeugen
            Rectangle balken = new Rectangle();
            Canvas.SetLeft(balken, position.X);
            Canvas.SetTop(balken, position.Y);
            balken.Width = laenge;
            balken.Height = breite;
            SolidColorBrush fuellung = new SolidColorBrush(Colors.Red);
            balken.Fill = fuellung;
            //der Balken hat den Namen grenze
            balken.Name = "Grenze";
            //und hinzufügen
            spielfeld.Children.Add(balken);
        }
        private void Timer_Spielzeit(object sender, EventArgs e)
        {
            //die Zeit erhöhen und neu anzeigen
            remainingTime = remainingTime - 1;
            zeitAnzeige.Content = remainingTime;
        }
    }
}
