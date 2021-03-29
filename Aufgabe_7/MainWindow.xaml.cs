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
            remainingTime = 12;
            points = 0;

            timerGameTime = new DispatcherTimer();
            timerGameTime.Interval = TimeSpan.FromMilliseconds(1000);
            timerGameTime.Tick += new EventHandler(Timer_Game_Duration);

            timerGameTime.Start();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DrawPlayground();
            timeDisplay.Content = remainingTime;
            pointDisplay.Content = points;
            button1.Content = "Press me";
            button1.Background = new SolidColorBrush(Colors.Orange);
            button1.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Timer_Game_Duration(object sender, EventArgs e)
        {
            // Determine boarders of button placement for the random function:
            int maxX = Convert.ToInt32(spielfeld.ActualWidth - button1.Width - boarderRectangle);
            int maxY = Convert.ToInt32(spielfeld.ActualHeight - button1.Height - boarderRectangle);

            // Reduce time to be displayed by -1:
            remainingTime = remainingTime - 1;
            timeDisplay.Content = remainingTime;

            button1.Margin = new Thickness(random.Next(maxX), random.Next(maxY), 0, 0);
            PBar.Value = remainingTime;

            string message = "Time has run out, unfortunately you lost.";
            string caption = "Time";

            // When game time is out stop the game and present message to user:
            if (remainingTime <= 0)
            {
                timerGameTime.Stop();
                // When user confirms then close form:
                if (MessageBox.Show(message, caption, MessageBoxButton.OK) == MessageBoxResult.OK)
                {
                    Close();
                }
            }
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            points++;
            pointDisplay.Content = points;
            string message = "Congratulations, you reached 10 points!";
            string caption = "Game finished, you won!";

            // When 10 points were collected stop the game and present message box to user:
            if (points > 9)
            {
                timerGameTime.Stop();
                // When user confirms then close form:
                if (MessageBox.Show(message,caption, MessageBoxButton.OK) == MessageBoxResult.OK)
                {
                    Close();
                }
            }
        }
    }
}
