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
        DispatcherTimer timerGameTime;
        Canvas myCanvas = new Canvas();
        public MainWindow()
        {
            InitializeComponent();
            boarderRectangle = 25;
            remainingTime = 120;
            points = 0;
            Rectangle rectangle = new Rectangle();

            timerGameTime = new DispatcherTimer();
            //das Intervall setzen
            timerGameTime.Interval = TimeSpan.FromMilliseconds(1000);
            //die Methode für das Ereignis zuweisen
            timerGameTime.Tick += new EventHandler(Timer_Spielzeit);
            timerGameTime.Start();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawPlayground();
            timeDisplay.Content = remainingTime;
            pointDisplay.Content = points;
        }
        void DrawPlayground()
        {
            //der Balken oben
            DrawRectangle(new Point(0, 0), spielfeld.ActualWidth, boarderRectangle);
            //der Balken rechts
            DrawRectangle(new Point(spielfeld.ActualWidth - boarderRectangle, 0), boarderRectangle, spielfeld.ActualHeight);
            //der Balken unten
            DrawRectangle(new Point(0, spielfeld.ActualHeight - boarderRectangle), spielfeld.ActualWidth, boarderRectangle);
            //und der Balken links
            DrawRectangle(new Point(0, 0), boarderRectangle, spielfeld.ActualHeight);
        }
        void DrawRectangle(Point position, double width, double height)
        {
            ////einen neuen Balken erzeugen
            Rectangle rectangle = new Rectangle();
            Canvas.SetLeft(rectangle, position.X);
            Canvas.SetTop(rectangle, position.Y);
            rectangle.Width = width;
            rectangle.Height = height;
            SolidColorBrush filling = new SolidColorBrush(Colors.Beige);
            rectangle.Fill = filling;
            rectangle.Name = "Boarder";
            spielfeld.Children.Add(rectangle);
        }
        private void Timer_Spielzeit(object sender, EventArgs e)
        {
            Random random = new Random(GetHashCode());
            int groesse = 20;
            remainingTime = remainingTime - 1;
            timeDisplay.Content = remainingTime;
            //int maxX = (int)Canvas.ActualWidth - groesse;
            //int maxY = (int)Canvas.ActualHeight - groesse;
            //positionieren
            Color farbe = Colors.Red;
            Ellipse kreis;
            Canvas meinCanvas = new Canvas();

            kreis = new Ellipse();

            Canvas.SetLeft(kreis, random.Next(50, 100));
            Canvas.SetTop(kreis, random.Next(50, 100));

            //die Größe setzen
            kreis.Width = groesse;
            kreis.Height = groesse;
            //Farbe setzen
            SolidColorBrush fuellung = new SolidColorBrush(farbe);
            kreis.Fill = fuellung;
            myCanvas.Children.Add(kreis);
        }
    }
}
