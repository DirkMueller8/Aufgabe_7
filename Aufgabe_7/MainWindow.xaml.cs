using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Aufgabe_7
{
    // Author: Dirk Mueller
    // Date: 29.03.2021
    //
    // Algorithm:
    // 1. Create Canvas for playground and place point and time indicator into it
    // 2. Place the button into the Canvas
    // 3. Let the button move randomly in the Canvas, in a frequency of 1/s
    // 4. When the button was "caught" (pressed) increment the points by 1.
    // 5. When time is over present message to user that he/she lost.
    // 6. When 10 points were reached present message to user with congratulations.


    public partial class MainWindow : Window
    {
        int remainingTime;
        int points;

        DispatcherTimer timerGameTime;
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            // Set the play time to 2 min:
            remainingTime = 120;
            points = 0;

            timerGameTime = new DispatcherTimer();

            // Timer interval is 1 s:
            timerGameTime.Interval = TimeSpan.FromMilliseconds(1000);
            timerGameTime.Tick += new EventHandler(Timer_Game_Duration);

            timerGameTime.Start();
        }

        // Upon loading of the window initialize values:
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timeDisplay.Content = remainingTime;
            pointDisplay.Content = points;
            btnCatchMe.Content = "Press me";
            btnCatchMe.Background = new SolidColorBrush(Colors.Red);
            btnCatchMe.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Timer_Game_Duration(object sender, EventArgs e)
        {
            string message = "Time has run out, unfortunately you lost.";
            string caption = "Time";

            // Determine boarders of button placement for the random function:
            int maxX = Convert.ToInt32(spielfeld.ActualWidth - btnCatchMe.Width);
            int maxY = Convert.ToInt32(spielfeld.ActualHeight - btnCatchMe.Height);

            // Reduce time to be displayed by 1:
            remainingTime = remainingTime - 1;
            // Update time display:
            timeDisplay.Content = remainingTime;

            // Determine the next random position of button:
            btnCatchMe.Margin = new Thickness(random.Next(maxX), random.Next(maxY), 0, 0);

            // Reduce time to be displayed by 1 in progress bar:
            PBar.Value = remainingTime;

            // When game time is out stop the game and present message to user:
            if (remainingTime <= 0)
            {
                timerGameTime.Stop();

                // When user confirms the message then close form:
                if (MessageBox.Show(message, caption, MessageBoxButton.OK) == MessageBoxResult.OK)
                {
                    Close();
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string message = "Congratulations, you reached 10 points!";
            string caption = "Game finished, you won!";

            // Increment points when button was clicked:
            points++;
            // Update point display:
            pointDisplay.Content = points;

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