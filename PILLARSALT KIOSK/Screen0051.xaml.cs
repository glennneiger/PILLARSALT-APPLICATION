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

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for Screen005.xaml
    /// </summary>
    public partial class Screen0051 : Window
    {
        public Screen0051()
        {
            InitializeComponent();
        }

        private void GotoPrevious(object sender, RoutedEventArgs e)
        {

        }

        private void GotoNext(object sender, RoutedEventArgs e)
        {

        }

        private void RemovePlaceHolderText(object sender, RoutedEventArgs e)
        {
            if (txtAccNumber.Text == "ACC. NUMBER HERE")
            {
                txtAccNumber.Text = "";
            }

        }
    }
}
