using System;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using GloryWindowsUserControl;
using PILLARSALT_KIOSK.AppCodes;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for Screen004.xaml
    /// </summary>
    public partial class Screen004 : Window
    {
        private static BackgroundWorker _bwStartCount;

        DoubleAnimation da = new DoubleAnimation();
        private DataTable _dtCountData;
        private string _rtnCountData;
        private string _countDataArr;
        private DataSet _ds;
        private int _colTotal = 0;

        public Screen004()
        {
            InitializeComponent();
            InitializeBackgroundWorker2();


            da.From = 30;
            da.To = 45;
            da.AutoReverse = true;
            da.RepeatBehavior = RepeatBehavior.Forever;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.6));

            gifImg.Visibility = Visibility.Hidden;
            txtProcessingAnim.Visibility = Visibility.Hidden;
        }

        private void InitializeBackgroundWorker2()
        {
            _bwStartCount = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };


            _bwStartCount.DoWork += new DoWorkEventHandler(_bwStartCount_DoWork);
            _bwStartCount.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bwStartCount_RunWorkerCompleted);
            _bwStartCount.ProgressChanged += new ProgressChangedEventHandler(_bwStartCount_ProgressChanged);
        }

        private void _bwStartCount_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.progressBar2.Value = e.ProgressPercentage;
        }

        private void _bwStartCount_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                // Finally, handle the case where the operation 
                // succeeded.
                //MessageBox.Show(e.Result.ToString());
                string countString = e.Result.ToString();
                //convert to datatable
                if (!String.IsNullOrEmpty(countString) && !countString.ToLower().Contains("ERROR".ToLower()))
                {
                    ConvertDataStringToDataSet(countString);
                    
                    //open screen005
                    Screen005 s5 = new Screen005();
                    s5.Activate();
                    s5.Show();
                    
                    //close curent window
                    Close();
                }
                else if (countString.ToLower().Contains("ERROR".ToLower()) || String.IsNullOrEmpty(countString))
                {
                   DialogScreen ds = new DialogScreen();
                    ds.Topmost = true;
                    ds.Activate();
                    ds.Show();

                    //close curent window
                    Close();
                }
            }
        }

        private void _bwStartCount_DoWork(object sender, DoWorkEventArgs e)
        {

            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // RunWorkerCompleted eventhandler.
            e.Result = DoStartCount(worker, e);
        }

        private void ConvertDataStringToDataSet(string countString)
        {
            _dtCountData = new DataTable();
            //prepare datatable for the array elements
            _ds = new DataSet();

            _dtCountData.Columns.Add("NOTE");
            _dtCountData.Columns.Add("QTY");
            _dtCountData.Columns.Add("TOTAL");

            string[] primeArray = countString.Split(',');
            for (int i = 0; i < primeArray.Length; i += 5)
            {
                int first = Convert.ToInt16(primeArray[i]);
                int second = Convert.ToInt16(primeArray[i + 1]);
                int third = first * second;
                if (second != 0)
                {
                    _colTotal += third;
                    _dtCountData.Rows.Add(first, second, third);
                }
                //MachineHandle.TotalAmountCounted = Convert.ToDecimal(_colTotal);
            }
            _ds.Tables.Add(_dtCountData);
            MachineHandle.CountDataSet = _ds;
        }

        public string DoStartCount(BackgroundWorker worker, DoWorkEventArgs e)
        {
            //MessageBox.Show("Do start");
            try
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    btnBack.IsEnabled = false;
                    btnStartCount.IsEnabled = false;
                    gifImg.Visibility = Visibility.Visible;
                    txtProcessingAnim.Text = "Processing request... PLEASE WAIT.";
                    txtProcessingAnim.HorizontalAlignment=HorizontalAlignment.Center;
                    txtProcessingAnim.Visibility = Visibility.Visible;
                }));
               

                //skip delock
                goto countStart;
                deLock:
                var delockStr = MachineHandle.DoGlyAsyncDeLock(MachineHandle.MHandle); //this method should be an await method

                Thread.Sleep(2000);
                //MessageBox.Show(delockStr);
                if (delockStr.Contains("SEQUENCE"))
                {
                    goto deLock;
                }


                countStart:
                //Do count start Delay 1 seconds
                Thread.Sleep(3000);
                var rtnCntStart = MachineHandle.DoGlyAsyncDeCntStart(MachineHandle.MHandle).Result; //this method should be an await method
                Thread.Sleep(10000);
                if (rtnCntStart.ToLower().Contains("SEQUENCE".ToLower()))
                {
                    goto deLock;
                }
                if (rtnCntStart.Contains("SUCCESS"))
                {
                    //deUnLock:

                    string sUl = MachineHandle.DoGlyAsyncDeUnLock(MachineHandle.MHandle);
                    Thread.Sleep(2000);
                    if (!sUl.Contains("ERROR"))
                    {
                        _rtnCountData = MachineHandle.DoCountData();
                        Thread.Sleep(3000);
                        if (!_rtnCountData.Contains("ERROR") && _rtnCountData != String.Empty)
                        {
                            //remove first part of string from the returned string
                            var countData = _rtnCountData.Split(':');
                            //create array from the second part of returned string
                            _countDataArr = countData[1];
                        }
                        else
                        {
                            return "With error UNABLETOCOUNT : " + _rtnCountData;
                        }
                    }
                    else
                    {
                        return "With error UNABLETOCOUNT : " + _rtnCountData;
                    }
                }



            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return _countDataArr;
        }

        private void GotoPrevious(object sender, RoutedEventArgs e)
        {
            string screenName = "Screen003";
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

        private void CallDoStartCount(object sender, RoutedEventArgs e)
        {
            _bwStartCount.RunWorkerAsync();
        }

    }
}
