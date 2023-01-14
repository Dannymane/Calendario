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
        //public ObservableCollection<Event> ChosenWeekEvents { get; set; }
        public MainViewModel ViewModel;


        public MainWindow()
        {
            InitializeComponent();
            Events = new ObservableCollection<Event>();
            //ChosenWeekEvents = new ObservableCollection<Event>();


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
            EventsCanvasPanel.Children.Clear();

            // Get the selected week
            ViewModel.SelectedDate = Calendar.SelectedDates[0];

            // Add the events for the selected week to the list
            foreach (Event ev in Events)
            {
                if (ev.Day >= ViewModel.Sunday && ev.Day < ViewModel.Sunday.AddDays(7))
                {
                    var eventCard = new EventControlCard(ev);

                switch (ev.Day.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        {
                            Canvas.SetLeft(eventCard, 53);
                            break;
                        }
                    case DayOfWeek.Monday:
                        {
                            Canvas.SetLeft(eventCard, 53 + 118);
                            break;
                        }
                    case DayOfWeek.Tuesday:
                        {
                            Canvas.SetLeft(eventCard, 53 + 118 *2);
                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            Canvas.SetLeft(eventCard, 53 + 118 *3);
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            Canvas.SetLeft(eventCard, 53 + 118 *4);
                            break;
                        }
                    case DayOfWeek.Friday:
                        {
                            Canvas.SetLeft(eventCard, 53 + 118 *5);
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            Canvas.SetLeft(eventCard, 53 + 118 *6);
                            break;
                        }
                }
                    Canvas.SetTop(eventCard, 29 + (int)Math.Round((ev.StartTime).TotalSeconds / 114.5));
                    EventsCanvasPanel.Children.Add(eventCard);
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
            //Refreshing the schedule plane
            Calendar_SelectedDatesChanged(Calendar, null);
        }
    }
}
