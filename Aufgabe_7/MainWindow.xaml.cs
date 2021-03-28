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
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            boarderRectangle = 25;
            remainingTime = 120;
            points = 0;

            timerGameTime = new DispatcherTimer();
            timerGameTime.Interval = TimeSpan.FromMilliseconds(1000);
            timerGameTime.Tick += new EventHandler(Timer_Game_Duration);

            timerGameTime.Start();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawPlayground();
            timeDisplay.Content = remainingTime;
            pointDisplay.Content = points;
            button1.Content = "Press me";
            button1.Background = new SolidColorBrush(Colors.Orange);
            button1.Foreground = new SolidColorBrush(Colors.Black);
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
        private void Timer_Game_Duration(object sender, EventArgs e)
        {
            int maxX = Convert.ToInt32(spielfeld.ActualWidth - button1.Width - boarderRectangle);
            int maxY = Convert.ToInt32(spielfeld.ActualHeight - button1.Height - boarderRectangle);

            remainingTime = remainingTime - 1;
            timeDisplay.Content = remainingTime;
            button1.Margin = new Thickness(random.Next(maxX), random.Next(maxY), 0, 0);

            PBar.Value = remainingTime;
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            int maxLeft = Convert.ToInt32(spielfeld.ActualWidth - button1.Width - boarderRectangle);
            int maxTop = Convert.ToInt32(spielfeld.ActualHeight - button1.Height - boarderRectangle);
            Random rand = new Random();
            button1.Margin = new Thickness(rand.Next(maxLeft), rand.Next(maxTop), 0, 0);
            points++;
            pointDisplay.Content = points;
        }
    }
}
