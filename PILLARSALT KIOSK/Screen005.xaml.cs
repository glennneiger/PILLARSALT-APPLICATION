using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using PILLARSALT_KIOSK.AppCodes;

namespace PILLARSALT_KIOSK
{
    using System.Globalization;

    /// <summary>
    /// Interaction logic for Screen005.xaml
    /// </summary>
    public partial class Screen005 : Window
    {
        public Screen005()
        {
            InitializeComponent();
            BindRecordToGrid();
        }

        public void BindRecordToGrid()
        {
            try
            {
                if (MachineHandle._retyInt > 0)
                {
                    btnRetry.Visibility = Visibility.Visible;
                    btnRetry.Content = "RECOUNT(" + MachineHandle._retyInt + ")";
                }
                else
                {
                    btnRetry.Visibility = Visibility.Hidden;
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(MachineHandle.CountDataTable);
                //clear grids datasource
                grdCount.DataContext = null;
                grdCount.ItemsSource = ds.Tables[0].DefaultView;
                //dSet.Tables[0].DefaultView;
                int totalAmount = 0;
                foreach (DataRow row in MachineHandle.CountDataTable.Rows)
                {
                    totalAmount += Convert.ToInt32(row["TOTAL"].ToString());
                }
                txtTotalCounted.Text = "NGN" + totalAmount.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show("GrdCount Err: " + ex.Message);
            }

        }

        private void GotoPrevious(object sender, RoutedEventArgs e)
        {
            MachineHandle._retyInt = 3;
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
            //MachineHandle.DoStoreForRetailer();
            MachineHandle._retyInt = 3;

            string screenName = "Screen0051";
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

        private void DoCloseGlory(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MachineHandle.DoCloseGlory();
        }

        private void DoCountRetry(object sender, RoutedEventArgs e)
        {
            MachineHandle._retyInt--;
            string screenName = "Screen003";
            var sm = new ScreenManager();
            sm.GetStateArray();
            ShowNextWindow(screenName);
        }
    }
}
