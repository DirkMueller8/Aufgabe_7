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
using System.Timers;

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
        DispatcherTimer timerHideTime;
        Random random = new Random();
        Button btn = new Button();


        public MainWindow()
        {
            InitializeComponent();
            boarderRectangle = 25;
            remainingTime = 120;
            points = 0;

            timerGameTime = new DispatcherTimer();
            timerGameTime.Interval = TimeSpan.FromMilliseconds(1000);
            timerGameTime.Tick += new EventHandler(Timer_Game_Duration);

            timerHideTime = new DispatcherTimer();
            timerHideTime.Interval = TimeSpan.FromMilliseconds(900);
            timerGameTime.Start();
            timerHideTime.Start();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawPlayground();
            timeDisplay.Content = remainingTime;
            pointDisplay.Content = points;

        }
        void DrawPlayground()
        {
            DrawRectangle(new Point(0, 0), spielfeld.ActualWidth, boarderRectangle);
            DrawRectangle(new Point(spielfeld.ActualWidth - boarderRectangle, 0), boarderRectangle, spielfeld.ActualHeight);
            DrawRectangle(new Point(0, spielfeld.ActualHeight - boarderRectangle), spielfeld.ActualWidth, boarderRectangle);
            DrawRectangle(new Point(0, 0), boarderRectangle, spielfeld.ActualHeight);
        }
        void DrawRectangle(Point position, double width, double height)
        {
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
        //private static Timer timer;
        private void Timer_Game_Duration(object sender, EventArgs e)
        {
            //Button btn = new Button();
            //btn.Height = 40;
            //btn.Width = 70;
            //btn.Content = "Click me";
            //btn.Background = new SolidColorBrush(Colors.Orange);
            //btn.Foreground = new SolidColorBrush(Colors.Black);

            //int groesse = 35;
            int maxLeft = Convert.ToInt32(spielfeld.ActualWidth - button1.Width- boarderRectangle);
            int maxTop = Convert.ToInt32(spielfeld.ActualHeight - button1.Height - boarderRectangle);
            remainingTime = remainingTime - 1;
            timeDisplay.Content = remainingTime;
            button1.Margin = new Thickness(random.Next(maxLeft), random.Next(maxTop), 0, 0);

            PBar.Value = remainingTime;
            //int maxX = (int)spielfeld.ActualWidth - groesse;
            //int maxY = (int)spielfeld.ActualHeight - groesse;

            //Canvas.SetLeft(btn, random.Next(boarderRectangle, maxX));
            //Canvas.SetTop(btn, random.Next(boarderRectangle, maxY));

            //spielfeld.Children.Add(btn);
            //timer = new System.Timers.Timer();
            //timer.Interval = 500;
            //timer.Start();
            //spielfeld.Children.Remove(btn);
        }
        //private void button1_Click(object sender, MouseEventArgs e)
        //{
        //    int maxLeft = Convert.ToInt32(spielfeld.ActualWidth - button1.Width);
        //    int maxTop = Convert.ToInt32(spielfeld.ActualHeight - button1.Height);
        //    Random rand = new Random();
        //    button1.Margin = new Thickness(rand.Next(maxLeft), rand.Next(maxTop), 0, 0);
        //}

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            int maxLeft = Convert.ToInt32(spielfeld.ActualWidth - button1.Width);
            int maxTop = Convert.ToInt32(spielfeld.ActualHeight - button1.Height);
            Random rand = new Random();
            button1.Margin = new Thickness(rand.Next(maxLeft), rand.Next(maxTop), 0, 0);
            points++;
            pointDisplay.Content = points;
        }
        //private void Timer_Spielzeit(object sender, EventArgs e)
        //{
        //    //Random random = new Random(GetHashCode());
        //    int groesse = 20;
        //    remainingTime = remainingTime - 1;
        //    timeDisplay.Content = remainingTime;
        //    int maxX = (int)spielfeld.ActualWidth - groesse;
        //    int maxY = (int)spielfeld.ActualHeight - groesse;
        //    //positionieren
        //    Color farbe = Colors.Red;
        //    Ellipse kreis;
        //    kreis = new Ellipse();

        //    Canvas.SetLeft(kreis, random.Next(boarderRectangle, maxX));
        //    Canvas.SetTop(kreis, random.Next(boarderRectangle, maxY));

        //    //die Größe setzen
        //    kreis.Width = groesse;
        //    kreis.Height = groesse;
        //    //Farbe setzen
        //    SolidColorBrush fuellung = new SolidColorBrush(farbe);
        //    kreis.Fill = fuellung;
        //    spielfeld.Children.Add(kreis);
        //}
    }
}
