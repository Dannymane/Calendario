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

namespace Calendario.UserControls
{
    /// <summary>
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(TimeSpan), typeof(TimePicker),
                new PropertyMetadata(TimeSpan.Zero));
        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public TimePicker()
        {
            InitializeComponent();
            UpdateTimeText();
        }
        private void UpdateTimeText()
        {
            HourTextBox.Text = Time.Hours.ToString("00");
            MinuteTextBox.Text = Time.Minutes.ToString("00");
        }

        private void HourTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(HourTextBox.Text, out int hours) && hours >= 0 && hours <= 23)
            {
                Time = new TimeSpan(hours, Time.Minutes, 0);
            }
            else
            {
                UpdateTimeText();
            }
        }

        private void MinuteTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(MinuteTextBox.Text, out int minutes) && minutes >= 0 && minutes <= 59)
            {
                Time = new TimeSpan(Time.Hours, minutes, 0);
            }
            else
            {
                UpdateTimeText();
            }
        }
    }
}
