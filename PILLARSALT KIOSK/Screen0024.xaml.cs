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
    /// Interaction logic for Screen0024.xaml
    /// </summary>
    public partial class Screen0024 : Window
    {
        private BackgroundWorker _bwGetDetails;

        public Screen0024()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void GotoNext(object sender, RoutedEventArgs e)
        {
            string screenName = "Screen003";
            var sm = new ScreenManager();
            sm.GetStateArray();
            ShowNextWindow(screenName);

            Close();
        }

        private void GotoPrevious(object sender, RoutedEventArgs e)
        {
            string screenName = "Screen0022";
            var sm = new ScreenManager();
            sm.GetStateArray();
            ShowNextWindow(screenName);

            Close();
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

        private void GetHolderDetails(object sender, RoutedEventArgs e)
        {
            _bwGetDetails.RunWorkerAsync();
        }


        private void InitializeBackgroundWorker()
        {
            _bwGetDetails = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };


            _bwGetDetails.DoWork += new DoWorkEventHandler(_bwGetDetails_DoWork);
            _bwGetDetails.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bwGetDetails_RunWorkerCompleted);
            _bwGetDetails.ProgressChanged += new ProgressChangedEventHandler(_bwGetDetails_ProgressChanged);
        }

        private void _bwGetDetails_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.progressBar2.Value = e.ProgressPercentage;
        }

        private void _bwGetDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                //MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // CancelAsync was called.
                //statusLbl.Text = "Canceled";
            }
            else
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    gifImg.Visibility = Visibility.Hidden;
                }));

                // Finally, handle the case where the operation succeeded.
                string countString = e.Result.ToString();
                if (!String.IsNullOrEmpty(countString) && !countString.ToLower().Contains("ERROR".ToLower()))
                {
                    //display account holder name here
                    txtProcessingAnim.FontSize = 40;
                    btnContinue.IsEnabled = true;
                    btnContinue.Visibility = Visibility.Visible;
                    btnBack.Visibility=Visibility.Visible;
                    btnContinue.Content = "YES";
                    btnBack.Content = "NO";
                    txtProcessingAnim.Text = e.Result.ToString();
                }
                else if (countString.ToLower().Contains("ERROR".ToLower()) || String.IsNullOrEmpty(countString))
                {
                    btnBack.Visibility = Visibility.Visible;
                }
            }
        }

        private void _bwGetDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // RunWorkerCompleted eventhandler.
            e.Result = DoGetAccuntDetails(worker, e);
        }

        private string DoGetAccuntDetails(BackgroundWorker worker, DoWorkEventArgs eventArgs)
        {


            return "ADESANYA OLUFEMI S.";
        }
    }
}
