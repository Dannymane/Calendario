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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendario.UserControls
{
    /// <summary>
    /// Interaction logic for EventControlCard.xaml
    /// </summary>
    public partial class EventControlCard : UserControl
    {
        public EventControlCard(Event ev)
        {
            InitializeComponent();
            DataContext = ev;
        }
    }
}
