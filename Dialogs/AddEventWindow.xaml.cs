using Calendario.Images;
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
using System.Windows.Shapes;

namespace Calendario.Dialogs
{
    /// <summary>
    /// Interaction logic for AddEventWindow.xaml
    /// </summary>
    public partial class AddEventWindow : Window
    {
        public Event Event { get; set; }

        public AddEventWindow()
        {
            InitializeComponent();
            Event = new Event();

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate the input
            if (string.IsNullOrEmpty(TitleTextBox.Text))
            {
                MessageBox.Show("Please enter a title for the event.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (DayPicker.SelectedDate == null)
            {
                MessageBox.Show("Please select a day for the event.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //if (StartTimePicker.SelectedDate == null || EndTimePicker.SelectedDate == null)
            //{
            //    MessageBox.Show("Please select a start time and end time for the event.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}
            if (StartTimePicker.Time >= EndTimePicker.Time)
            {
                MessageBox.Show("The end time must be after the start time.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Set the properties of the event
            Event.Title = TitleTextBox.Text;
            Event.Day = DayPicker.SelectedDate.Value;
            Event.StartTime = StartTimePicker.Time;
            Event.EndTime = EndTimePicker.Time;
            Event.Location = LocationTextBox.Text;
            Event.Description = DescriptionTextBox.Text;


            // Close the dialog
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the dialog
            DialogResult = false;
            Close();
        }
    }
}
