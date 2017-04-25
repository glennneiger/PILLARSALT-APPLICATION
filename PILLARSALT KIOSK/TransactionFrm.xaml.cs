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
using SocketLibrary;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for TransactionFrm.xaml
    /// </summary>
    public partial class TransactionFrm : Window
    {
        public TransactionFrm()
        {
            InitializeComponent();
        }

        private void GetGridData(object sender, RoutedEventArgs e)
        {
            Content grdContent = TransactionCls.DenominationContents;
            if (grdContent != null)
            {
                int sumTotal = 0;
                int amount = 0;
                TxtDenomData.Text = "Note \tQty \tAmount\n";
                foreach (var items in grdContent.Parameters)
                {
                    amount = Convert.ToInt16(items.Text) * Convert.ToInt16(items.Value);
                    TxtDenomData.Text += items.Text + " \t" + items.Value + " \t" +
                                         amount + "\n";
                    sumTotal += amount;
                }
                TxtSumTotal.Text += sumTotal.ToString();

            }

        }


        private void GoToMaimMenu(object sender, RoutedEventArgs e)
        {
            string screenName = "Screen002";
            Sm = new ScreenManager();
            string pScreen = this.Name;
            Array stateArr = Sm.GetStateArray();

            ShowNextWindow(screenName);
        }

        public ScreenManager Sm { get; set; }

        private void PrintReceipt(object sender, RoutedEventArgs e)
        {

        }
        void ShowNextWindow(string windowFileName)
        {
            var window = (Window)Application.LoadComponent(new Uri(windowFileName + ".xaml", UriKind.Relative));
            window.Topmost = true;
            window.WindowStyle = WindowStyle.None;
            window.WindowState = WindowState.Maximized;
            window.Owner = this;
            window.Show();
        }

    }
}
