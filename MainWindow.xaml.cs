using Calendario.Images;
﻿using System;
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
        public ObservableCollection<Event> Events { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            plnMainGrid.MouseDown += new MouseButtonEventHandler(plnMainGrid_MouseDown);//
            Events = new ObservableCollection<Event>();
            //Calendar.SelectedDatesChanged += Calendar_SelectedDatesChanged;
        }

  //      private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Clear the appointments list
        //    AppointmentsDataGrid.Items.Clear();

        //    // Get the selected week
        //    Calendar calendar = sender as Calendar;
        //    DateTime startOfWeek = calendar.SelectedDates[0];
        //    DateTime endOfWeek = startOfWeek.AddDays(7);

        //    // Add the appointments for the selected week to the list
        //    foreach (Appointment appointment in Appointments)
        //    {
        //        if (appointment.StartTime >= startOfWeek && appointment.EndTime < endOfWeek)
        //        {
        //            AppointmentsDataGrid.Items.Add(appointment);
        //        }
        //    }
   //     }
        private void plnMainGrid_MouseUp(object sender, MouseButtonEventArgs e)//
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
            
        }

        private void plnMainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("at " + e.GetPosition(this).ToString());
        }
    }
}
