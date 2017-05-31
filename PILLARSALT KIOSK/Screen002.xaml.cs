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
    /// Interaction logic for Screen002.xaml
    /// </summary>
    public partial class Screen002 : Window
    {
        public Screen002()
        {
            InitializeComponent();
        }

        private void GotoNext(object sender, RoutedEventArgs e)
        {
            MethodManager.DoAppLog(2, "b", "c", "d", "e", "f", "g");

            string screenName = "Screen0021";
            //var sm = new ScreenManager();
            //string pScreen = this.Name;
            //Array stateArr = sm.GetStateArray();

            ShowNextWindow(screenName);
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
        //private void GotoNext(object sender, TouchEventArgs e)
        //{
        //    MethodManager.DoAppLog(2, "b", "c", "d", "e", "f", "g");

        //    string screenName = "Screen003";
        //    //var sm = new ScreenManager();
        //    //string pScreen = this.Name;
        //    //Array stateArr = sm.GetStateArray();

        //    ShowNextWindow(screenName);
        //}

        private void GotoNext1(object sender, RoutedEventArgs e)
        {
            MethodManager.DoAppLog(3, "b", "c", "d", "e", "f", "g");

            string screenName = "Screen080";
            //var sm = new ScreenManager();
            //string pScreen = this.Name;
            //Array stateArr = sm.GetStateArray();
            try
            {
                ShowNextWindow(screenName);
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }

        private void GotoPrev(object sender, RoutedEventArgs e)
        {
            string screenName = "Screen001";
            //var sm = new ScreenManager();
            //string pScreen = this.Name;
            //Array stateArr = sm.GetStateArray();

            ShowNextWindow(screenName);
        }

        private void GotoPrev(object sender, TouchEventArgs e)
        {
            string screenName = "Screen001";
            //var sm = new ScreenManager();
            //string pScreen = this.Name;
            //Array stateArr = sm.GetStateArray();

            ShowNextWindow(screenName);
        }


    }
}
