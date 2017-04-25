using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using PILLARSALT_KIOSK.AppCodes;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for Screen004.xaml
    /// </summary>
    public partial class Screen004 : Window
    {
        DoubleAnimation da = new DoubleAnimation();
        private DataTable _dtCountData;
        public Screen004()
        {
            InitializeComponent();

            da.From = 30;
            da.To = 45;
            da.AutoReverse = true;
            da.RepeatBehavior = RepeatBehavior.Forever;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.6));
        }

        private void DoStartCount(object sender, RoutedEventArgs e)
        {

            BusyScreen bs = new BusyScreen();
            Topmost = true;
            bs.txtProcessing.Text = "Count in progress..., please wait!";
            bs.Show();
            Task t = Task.Run(() =>
            {
                try
                {
                    _dtCountData = new DataTable();
                    _dtCountData = MachineHandle.DoStartCount();
                }
                catch (Exception ex)
                {
                    //Log Error to ErrorLog
                }
            });
            t.Wait();
            Thread.Sleep(1000);

            t.

            if (_dtCountData.Rows.Count > 0)
            {
                bs.Close();
                Close();

                Screen005 screen005 = new Screen005();
                screen005.Show();
            }
            else
            {
                DialogScreen ds = new DialogScreen();
                ds.txtDialogMessage.Text = "COUNT FAILED, REMOVE NOTES, ARRANGE PROPERLY AND PLACE NOTE IN THE HOPPER, PRESS START-COUNT TO TRY AGAIN!";
                ds.Topmost = true;
                ds.Show();
            }
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

    }
}
