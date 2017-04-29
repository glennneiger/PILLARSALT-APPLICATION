using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using PILLARSALT_KIOSK.AppCodes;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for Screen005.xaml
    /// </summary>
    public partial class Screen005 : Window
    {
        //private string _handle = MachineHandle.MHandle;

        public Screen005()
        {
            InitializeComponent();
            BindRecordToGrid(MachineHandle.CountDataSet);
        }


        public void BindRecordToGrid(DataSet dSet)
        {
            try
            {
                //clear grids datasource
                grdCount.DataContext = null;
                grdCount.ItemsSource = dSet.Tables[0].DefaultView;
                int totalAmount = 0;
                foreach (DataTable table in dSet.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        totalAmount += Convert.ToInt32(row["TOTAL"].ToString());
                    }
                }
                txtTotalCounted.Text = totalAmount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("GrdCount Err: " + ex.Message);
            }

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

        private void DoAcceptStoreCash(object sender, RoutedEventArgs e)
        {
            //await DropAndPost();
            MachineHandle.DoStoreForRetailer();
            string screenName = "TransactionFrm";
            var sm = new ScreenManager();
            sm.GetStateArray();
            ShowNextWindow(screenName);
        }

        private Task DropAndPost()
        {
            MachineHandle.DoStoreForRetailer();
            string screenName = "Screen002";
            var sm = new ScreenManager();
            sm.GetStateArray();
            ShowNextWindow(screenName);
            return null;
        }

        private void DoRejectOpenEscrow(object sender, RoutedEventArgs e)
        {
            string r = MachineHandle.DoRejectOpenEscrow();
            Thread.Sleep(2000);
            if (!r.ToLower().Contains("error".ToLower()))
            {
                string screenName = "Screen002";
                var sm = new ScreenManager();
                sm.GetStateArray();
                ShowNextWindow(screenName);
            }
        }

        private void BindRecordToGrid(object sender, RoutedEventArgs e)
        {
            BindRecordToGrid(MachineHandle.CountDataSet);
        }

        private void DoCloseGlory(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MachineHandle.DoCloseGlory();
        }
    }
}
