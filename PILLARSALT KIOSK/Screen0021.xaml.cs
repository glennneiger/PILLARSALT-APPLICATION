using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PILLARSALT_KIOSK.AppCodes;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for Screen0021.xaml
    /// </summary>
    public partial class Screen0021 : Window, INotifyPropertyChanged
    {
        public Screen0021()
        {
            InitializeComponent();

        }
        #region Public Properties

        private string _result;
        public string Result
        {
            get { return _result; }
            private set { _result = value; this.OnPropertyChanged("Result"); }

        }
        #endregion

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


        private void GotoNext(object sender, RoutedEventArgs e)
        {
            string screenName = "Screen0022";
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
                            phoneNumberTxt.Text = Result;
                        }
                        break;

                    default:
                        Result += button.Content.ToString();
                        phoneNumberTxt.Text = Result;
                        break;
                }
        }

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
            if (phoneNumberTxt.Text.Length == 11)
            {
                btnContinue.IsEnabled = true;
            }
            else
            {
                btnContinue.IsEnabled = false;
            }
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            phoneNumberTxt.Text = "";
        }

        private void AddText(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(phoneNumberTxt.Text))
                phoneNumberTxt.Text = "08000000000";
        }
    }
}
