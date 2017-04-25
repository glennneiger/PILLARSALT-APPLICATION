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
using PILLARSALT_KIOSK.AppCodes;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for Screen001.xaml
    /// </summary>
    public partial class Screen001 : Window
    {
        private ScreenManager _sm;

        public Screen001()
        {
            InitializeComponent();
        }

        private void GoToMaimMenu(object sender, RoutedEventArgs e)
        {
            _sm = new ScreenManager();
            string pScreen = this.Name;
            Array stateArr = _sm.GetStateArray();
            ShowNextWindow("Screen002");
        }
        void ShowNextWindow(string windowFileName)
        {
            var window = (Window)Application.LoadComponent(new Uri(windowFileName + ".xaml", UriKind.Relative));
            window.Topmost = true;
            window.WindowStyle = WindowStyle.None;
            window.WindowState = WindowState.Maximized;
            //window.Owner = this;
            window.Show();
            this.Close();
        }

        private void GotoIdleScreen(object sender, RoutedEventArgs e)
        {
            _sm = new ScreenManager();
            string pScreen = this.Name;
            Array stateArr = _sm.GetStateArray();
            ShowNextWindow("Screen000");
        }
    }
}
