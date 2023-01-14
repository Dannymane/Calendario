using Calendario.Dialogs;
using Calendario.Images;
using Calendario.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Calendario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime sunday, monday, tuesday, wednesday, thursday, friday, saturday, selectedDate;
        public DateTime Sunday
        {
            get { return sunday; }
            set
            {
                sunday = value;
                RaisePropertyChanged("Sunday");
            }
        }
        public DateTime Monday
        {
            get { return monday; }
            set
            {
                monday = value;
                RaisePropertyChanged("Monday");
            }
        }
        public DateTime Tuesday
        {
            get { return tuesday; }
            set
            {
                tuesday = value;
                RaisePropertyChanged("Tuesday");
            }
        }
        public DateTime Wednesday
        {
            get { return wednesday; }
            set
            {
                wednesday = value;
                RaisePropertyChanged("Wednesday");
            }
        }
        public DateTime Thursday
        {
            get { return thursday; }
            set
            {
                thursday = value;
                RaisePropertyChanged("Thursday");
            }
        }
        public DateTime Friday
        {
            get { return friday; }
            set
            {
                friday = value;
                RaisePropertyChanged("Friday");
            }
        }
        public DateTime Saturday
        {
            get { return saturday; }
            set
            {
                saturday = value;
                RaisePropertyChanged("Saturday");
            }
        }

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                RaisePropertyChanged("SelectedDate");


                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(value);
                if (day >= DayOfWeek.Sunday)
                    Sunday = value.AddDays(DayOfWeek.Sunday - day);
                else
                    Sunday = value.AddDays(-(day - DayOfWeek.Sunday));
                Monday = Sunday.AddDays(1);
                Tuesday = Sunday.AddDays(2);
                Wednesday = Sunday.AddDays(3);
                Thursday = Sunday.AddDays(4);
                Friday= Sunday.AddDays(5);
                Saturday= Sunday.AddDays(6);
            }
        }

        public MainViewModel(DateTime SelectedDate_)
        {
            SelectedDate = SelectedDate_;
        }
        // PropertyChanged event implementation
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void NotifyPropertyChanged()
        {
            throw new NotImplementedException();
        }
        //INotifyPropertyChanged members and function
    }

    public partial class MainWindow : Window
    {
        //private Calendar calendar;
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<Event> ChosenWeekEvents { get; set; }
        public MainViewModel ViewModel;


        public MainWindow()
        {
            InitializeComponent();
            Events = new ObservableCollection<Event>();
            ChosenWeekEvents = new ObservableCollection<Event>();


            Calendar.SelectedDate = DateTime.Today;
            ViewModel = new MainViewModel(Calendar.SelectedDates[0]);
            this.DataContext = ViewModel;

            Calendar.SelectedDatesChanged += Calendar_SelectedDatesChanged;
            //ChosenWeekEvents.CollectionChanged += 


            //Binding binding = new Binding("Text");
            //binding.Source = sunday.ToString("dd");
            //mon.SetBinding(TextBlock.TextProperty, binding);
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // Clear the events list
            //EventsCanvasPanel.Children.Clear();
            ChosenWeekEvents.Clear();
            // Get the selected week
            //Calendar calendar = sender as Calendar;
            ViewModel.SelectedDate = Calendar.SelectedDates[0];

            // Add the events for the selected week to the list
            foreach (Event ev in Events)
            {
                if (ev.Day >= ViewModel.Sunday && ev.Day < ViewModel.Sunday.AddDays(7))
                {
                    var eventCard = new EventControlCard(ev);
                    EventsCanvasPanel.Children.Add(eventCard);
                    Canvas.SetTop(eventCard, 100);
                    Canvas.SetLeft(eventCard, 55);

                    //ev.X = 400;
                    //ev.Y = 400;
                    //ChosenWeekEvents.Add(ev);

                    //EventWindow window = new EventWindow(ev);
                    //EventsCanvasPanel.Children.Add(window);
                    //Canvas.SetTop(window, 100);
                    //Canvas.SetLeft(window, 100);
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
            //DateTime sunday = calendar.SelectedDates [0];
            // DateTime endOfWeek = sunday.AddDays(7);
            // if (event.StartTime >= sunday && event.EndTime < endOfWeek)
            // {
            //     EventsDataGrid.Items.Add(event);
            // }
        }
    }
}
