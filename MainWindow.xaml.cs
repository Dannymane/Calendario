using Calendario.Images;
﻿using System;
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

namespace Calendario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            plnMainGrid.MouseDown += new MouseButtonEventHandler(plnMainGrid_MouseDown);//
        }


        private void plnMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
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
