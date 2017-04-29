using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PILLARSALT_KIOSK.AppCodes;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for Screen0023.xaml
    /// </summary>
    public partial class Screen0023 : Window
    {
        public Screen0023()
        {
            InitializeComponent();

            GetRegisteredBanksList();

            listbox.SelectionChanged += ListboxOnSelectionChanged;
            listbox1.SelectionChanged += Listbox1OnSelectionChanged;
        }

        private void Listbox1OnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (listbox1.SelectedItems.Count > 0)
            {
                btnContinue.IsEnabled = true;
            }
            listbox.UnselectAll();
        }

        private void ListboxOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (listbox.SelectedItems.Count > 0)
            {
                btnContinue.IsEnabled = true;
            }
           listbox1.UnselectAll();
        }

        private DataTable _dt;
        private Dictionary<string, string> _bankDictionary;

        private void GetRegisteredBanksList()
        {
            _dt = new DataTable();

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
        private void GotoNext(object sender, RoutedEventArgs e)
        {
            string screenName = "Screen0024";
            var sm = new ScreenManager();
            sm.GetStateArray();
            ShowNextWindow(screenName);
        }

        private void GotoPrevious(object sender, RoutedEventArgs e)
        {
            string screenName = "Screen0021";
            var sm = new ScreenManager();
            sm.GetStateArray();
            ShowNextWindow(screenName);
        }

        private async void GetAccountOwnerDetails(object o, RoutedEventArgs e)
        {
            //perform await funtion to get accout holder details

            var bs = new BusyScreen();
            bs.Show();
            bs.Topmost = true;
            await Task.Delay(3000);
            bs.Close();

            //txtAccountHolder.Text = "ADESANYA OLUFEMI S. :-: Number :-: " + accNumberTxt.Text + " Bank :-: " + txtBankName.Text;



            //if successful enable continue btn
            btnContinue.IsEnabled = true;
        }


    }


}
