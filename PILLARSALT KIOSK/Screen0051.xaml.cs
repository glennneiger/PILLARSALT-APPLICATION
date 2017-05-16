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
            //open escrow
            var s = MachineHandle.DoRejectOpenEscrow();
            if (!s.ToLower().Contains("error".ToLower()))
            {
                string screenName = "Screen002";
                var sm = new ScreenManager();
                sm.GetStateArray();

                ShowNextWindow(screenName);
            }
        }
        void ShowNextWindow(string windowFileName)
        {
            var window = (Window)Application.LoadComponent(new Uri(windowFileName + ".xaml", UriKind.Relative));
            window.Topmost = true;
            window.WindowStyle = WindowStyle.None;
            window.WindowState = WindowState.Maximized;
            //window.Owner = this;
            window.Show();

            Close();
        }

        private void RemovePlaceHolderText(object sender, RoutedEventArgs e)
        {

        }

        private void DoAcceptStoreCash()
        {
            //await DropAndPost();
            //MachineHandle.DoStoreForRetailer();
            string screenName = "TransactionFrm";
            var sm = new ScreenManager();
            sm.GetStateArray();
            ShowNextWindow(screenName);
        }

        private void GotoNext(object sender, RoutedEventArgs e)
        {
            //open escrow
            //string screenName = "Screen002";
            //var sm = new ScreenManager();
            //sm.GetStateArray();
            //ShowNextWindow(screenName);
            DoAcceptStoreCash();
        }
    }
}
