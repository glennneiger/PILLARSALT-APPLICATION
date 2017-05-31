using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Screen0022.xaml
    /// </summary>
    public partial class Screen0022 : Window
    {
        public Screen0022()
        {
            InitializeComponent();
        }

        private void GotoNext(object sender, RoutedEventArgs e)
        {
            Banks.AccountNumber = accNumberTxt.Text;

            string screenName = "Screen0023";
            var sm = new ScreenManager();
            sm.GetStateArray();
            ShowNextWindow(screenName);
        }

        private void GotoPrevious(object sender, RoutedEventArgs e)
        {
            string screenName = "Screen002";
            var sm = new ScreenManager();
            sm.GetStateArray();
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

            Close();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
                switch (button.CommandParameter.ToString())
                {
                    //case "ESC":
                    //    this.DialogResult = false;
                    //    break;

                    //case "RETURN":
                    //    this.DialogResult = true;
                    //    break;

                    case "BACK":
                        if (Result.Length > 0)
                        {
                            Result = Result.Remove(Result.Length - 1);
                            accNumberTxt.Text = Result;
                        }
                        break;

                    default:
                        Result += button.Content.ToString();
                        accNumberTxt.Text = Result;
                        break;
                }
        }


        #region Public Properties

        private string _result;
        public string Result
        {
            get { return _result; }
            private set { _result = value; this.OnPropertyChanged("Result"); }

        }
        #endregion
        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        private void FncEnableContinueBtn(object sender, TextChangedEventArgs e)
        {
            if (accNumberTxt.Text.Length == 10)
            {
                btnContinue.IsEnabled = true;
            }
            else
            {
                btnContinue.IsEnabled = false;
            }
        }
    }
}
