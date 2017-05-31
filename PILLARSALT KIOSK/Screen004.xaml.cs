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

        private string _rtnCountData;
        private string _countDataArr;
        private DataSet _ds;
        private double _colTotal = 0.00;

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
                try
                {
                    // Finally, handle the case where the operation 
                    // succeeded.
                    MachineHandle.CountString = null;
                    MachineHandle.CountString = e.Result.ToString();
                    //MessageBox.Show(MachineHandle.CountString);
                    this.txtResult.Text = MachineHandle.CountString;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error : " + ex.Message);
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
            try
            {
                MachineHandle.CountDataTable = new DataTable();

                MachineHandle.CountDataTable.Columns.Add("NOTE");
                MachineHandle.CountDataTable.Columns.Add("QTY");
                MachineHandle.CountDataTable.Columns.Add("TOTAL");
                string rtnStr = String.Empty;

                string[] str = countString.Split(',');
                for (int i = 0; i < 52; i++)
                {
                    rtnStr += str[i] + ",";
                }

                string[] split3 = rtnStr.Split(',');
                for (int i = 0; i < split3.Length; i += 5)
                {
                    int first = Convert.ToInt16(split3[i]);
                    int second = Convert.ToInt16(split3[i + 1]);
                    int third = first * second;
                    if (second > 0)
                    {
                        //MessageBox.Show($"Am in split3 loop : {first}\t{second}\t{third}");
                        MachineHandle.CountDataTable.Rows.Add(first, second, third);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(@"Inside Convert Data String To DataSet! " + ex.Message);
            }
        }

        public string DoStartCount(BackgroundWorker worker, DoWorkEventArgs e)
        {
            try
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    btnBack.Visibility = Visibility.Hidden;
                    btnStartCount.IsEnabled = false;
                    gifImg.Visibility = Visibility.Visible;
                    txtProcessingAnim.Text = "Processing request... PLEASE WAIT.";
                    txtProcessingAnim.HorizontalAlignment = HorizontalAlignment.Center;
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
                Thread.Sleep(15000); //delay 10 seconds before calling the next method
                if (rtnCntStart.ToLower().Contains("SEQUENCE".ToLower()))
                {
                    goto deLock;
                }
                if (rtnCntStart.Contains("SUCCESS"))
                {
                    //get escrow counter status
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

        private void OnTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //convert string to datatable
            if (!String.IsNullOrEmpty(this.txtResult.Text) && !this.txtResult.Text.ToLower().Contains("ERROR".ToLower()))
            {
                ConvertDataStringToDataSet(txtResult.Text);

                Thread.Sleep(2000);
                ////open screen005
                ShowNextWindow("Screen005");
            }
            else if (this.txtResult.Text.ToLower().Contains("ERROR".ToLower()) || String.IsNullOrEmpty(this.txtResult.Text.ToLower()))
            {
                ////open Dialog Window
                ShowNextWindow("DialogScreen");

            }
        }
    }
}

