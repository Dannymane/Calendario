using Calendario.Dialogs;
using Calendario.Images;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Calendario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calendar calendar;
        public ObservableCollection<Event> Events { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Events = new ObservableCollection<Event>();
            Calendar.SelectedDatesChanged += Calendar_SelectedDatesChanged;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // Clear the events list
            EventsCanvasPanel.Children.Clear();

            // Get the selected week
            //Calendar calendar = sender as Calendar;
            DateTime startOfWeek = Calendar.SelectedDates[0];
            DateTime endOfWeek = startOfWeek.AddDays(7);

            // Add the events for the selected week to the list
            foreach (Event ev in Events)
            {
                if (ev.Day >= startOfWeek && ev.Day < endOfWeek)
                {
                    EventWindow window = new EventWindow(ev);
                    EventsCanvasPanel.Children.Add(window);
                    Canvas.SetTop(window, 100);
                    Canvas.SetLeft(window, 100);
                }
            }
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            // Display a dialog to add a new event
            AddEventWindow addEventWindow = new AddEventWindow();
            addEventWindow.ShowDialog();

            // If the user clicks "OK" in the dialog, add the event to the list
            if (addEventWindow.DialogResult.HasValue && addEventWindow.DialogResult.Value)
            {
                Event ev = addEventWindow.Event;
                Events.Add(ev);

             }
            // If the event is in the currently selected week, add it to the list
            //DateTime startOfWeek = calendar.SelectedDates [0];
            // DateTime endOfWeek = startOfWeek.AddDays(7);
            // if (event.StartTime >= startOfWeek && event.EndTime < endOfWeek)
            // {
            //     EventsDataGrid.Items.Add(event);
            // }
        }
    }
}
