using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using GloryWindowsUserControl;
using PILLARSALT_KIOSK.AppCodes;
using SocketLibrary;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for Screen004.xaml
    /// </summary>
    public partial class Screen0041
    {
        private string _handle = String.Empty;
        private string _machineOwner = String.Empty;

        public Screen0041()
        {
            InitializeComponent();
        }

        private void GotoPrevious(object sender, RoutedEventArgs e)
        {
            //before going back, do a open escrow
            //prompt user to take money
            //redirect to DASHBOARD screen


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


        private void DoRejectOpenEscrow(object sender, RoutedEventArgs e)
        {

        }

        private void DoAcceptStoreCash(object sender, RoutedEventArgs e)
        {
            ////Go to user account details if user is not retailler
            //if (_machineOwner.Contains("Retailer"))
            //{
            if (_handle != null) DoStoreForRetailer(_handle);
            //call method to post cash to owner account

            //}
            //else
            //{
            //    ShowNextWindow("Screen005");
            //}

        }

        private void GoToUserAccountPage()
        {

        }
        #region machine methods begins 
        public Content Content1 { get; set; }
        public GloryWinUserControl Gctrl = new GloryWinUserControl();

        public static T IsWindowOpen<T>(string name = null)
            where T : Window
        {
            var windows = Application.Current.Windows.OfType<T>();
            return string.IsNullOrEmpty(name) ? windows.FirstOrDefault() : windows.FirstOrDefault(w => w.Name.Equals(name));
        }

        public DataGridCell GetCell(int row, int column)
        {
            DataGridRow rowContainer = GetRow(row);

            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    grdCount.ScrollIntoView(rowContainer, grdCount.Columns[column]);
                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
        }

        public DataGridRow GetRow(int index)
        {
            DataGridRow row = (DataGridRow)grdCount.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                grdCount.UpdateLayout();
                grdCount.ScrollIntoView(grdCount.Items[index]);
                row = (DataGridRow)grdCount.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
        private void DoStartCount(object sender, RoutedEventArgs e)
        {

            //start glory
            string rtn = null;
            int colTotal = 0;
            txtTotalCounted.Text = "";
            //open glory again to recount
            string[] words = null;

            if (_handle.Equals("") || _handle == null)
            {
                rtn = Gctrl.DoGloryOpen("DLLTEST");
                MessageBox.Show(rtn);
            }

            if (rtn != null) words = rtn.Split(',');
            if (words != null) _handle = words[1];

            try
            {
                BusyScreen bs = new BusyScreen();
                MoreNote mn = new MoreNote();
                DialogScreen dialog = new DialogScreen();

                bs.Topmost = true;
                bs.ShowDialog();


                //skip delock
                goto countStart;

                deLock: //call method to delock glory if error occur in glory
                Gctrl.DoGlyAsyncDeLock(_handle);


                countStart:
                //Do count start Delay 3 seconds
                Thread.Sleep(3000);
                var rtnCntStart = Gctrl.DoGlyAsyncDeCntStart(_handle);
                if (rtnCntStart.Contains("ERROR"))
                {
                    goto deLock;
                }

                //Delay 3 seconds
                Thread.Sleep(3000);
                var rtnCountData = Gctrl.DoCountData();

                if (!rtnCountData.Contains("ERROR") && rtnCountData != "")
                {
                    //remove first part of string from the returned string
                    var countData = rtnCountData.Split(':');
                    //create array from the second part of returned string
                    var countDataArr = countData[1];
                    var primeArray = countDataArr.Split(',');

                    //prepare datatable for the array elements
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();

                    dt.Columns.Add("NOTE");
                    dt.Columns.Add("QUANTITY");
                    dt.Columns.Add("TOTAL");


                    for (int i = 0; i < primeArray.Length; i += 5)
                    {
                        int first = Convert.ToInt16(primeArray[i]);
                        int second = Convert.ToInt16(primeArray[i + 1]);
                        int third = first * second;
                        if (second != 0)
                        {
                            colTotal += third;
                            dt.Rows.Add(first, second, third);
                        }
                    }

                    ds.Tables.Add(dt);
                    //clear grids datasource
                    grdCount.DataContext = null;
                    grdCount.ItemsSource = ds.Tables[0].DefaultView;
                    txtTotalCounted.Text = colTotal.ToString();

                    //disable start-count btn
                    if (colTotal != 0)
                    {
                        mn.Topmost = true;
                        mn.ShowDialog();

                        btnBack.IsEnabled = false;
                        btnStartCount.Content = "ADD-MORE";
                        btnStartCount.IsEnabled = true;
                        btnAccept.IsEnabled = true;
                        btnReject.IsEnabled = true;

                    }
                    else
                    {
                        btnBack.IsEnabled = true;
                        btnStartCount.IsEnabled = true;
                        btnAccept.IsEnabled = false;
                        btnReject.IsEnabled = false;
                        btnStartCount.Content = "START-COUNT";

                        bs.Close();
                        mn.Close();
                    }

                    //bs.Close();
                    //mn.Close();

                    var window = IsWindowOpen<Window>("Deposit");
                    if (window != null)
                    {
                        window.Close();
                    }

                    var winDepCount = IsWindowOpen<Window>("DepositCount");
                    if (winDepCount != null)
                    {
                        winDepCount.WindowStyle = WindowStyle.None;
                        winDepCount.Activate();
                        winDepCount.Topmost = true;
                        winDepCount.ShowDialog();
                    }
                    //await PutMethodDelay(5000);
                    Thread.Sleep(2000);
                }
                else
                {
                    dialog.Topmost = true;
                    dialog.ShowDialog();

                    //_dialog.Close();
                    bs.Close();

                    //close glory bcos count is empty
                    Gctrl.DoGloryClose(_handle);
                    _handle = null;
                    Thread.Sleep(2000);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Content ReadGridContent()
        {
            //send denomnation data too
            var denomContent = new Content
            {
                MethodCall = "Denomination",
                MethodId = new Guid().ToString("D")
            };

            //instantiate PiarOutput for Denomination
            var denomParams = new List<Common.PairOutput>();
            var param5 = new Common.PairOutput
            {
                Text = "TransactionId",
                Value = new Guid().ToString("D")
            };
            denomParams.Add(param5);

            for (int i = 0; i < grdCount.Items.Count; i++)
            {
                //loop throught cell
                var cell1 = GetCell(i, 0);
                var cell2 = GetCell(i, 1);
                TextBlock tb1 = cell1.Content as TextBlock;
                TextBlock tb2 = cell2.Content as TextBlock;

                if (tb1 != null)
                {
                    MessageBox.Show(tb1.Text);
                    if (tb2 != null)
                    {
                        MessageBox.Show(tb2.Text);

                        var a = new Common.PairOutput
                        {
                            Text = "Currency",
                            Value = "NGN"
                        };
                        var b = new Common.PairOutput
                        {
                            Text = "Denomination",
                            Value = tb1.Text
                        };
                        var c = new Common.PairOutput
                        {
                            Text = "Quantity",
                            Value = tb2.Text
                        };
                        denomParams.Add(a);
                        denomParams.Add(b);
                        denomParams.Add(c);
                    }
                }
            }
            denomContent.Parameters = denomParams;

            //DenominationContents = denomContent;

            return denomContent;
        }

        public void DoStoreForRetailer(string handle)
        {
            txtTotalCounted.Text = "125500";
            //MethodManager mm = new MethodManager();
            if (txtTotalCounted.Text != "")
            {
                //var sockIp = ConfigurationManager.AppSettings["SocketIp"];
                //var sockPort = ConfigurationManager.AppSettings["SocketPort"];

                var messageType = "KIOSK-REQUEST";
                //var origin = "6a7eb98f-a3ef-4e1a-9fc7-66365c2a3778";
                var origin = MethodManager.GetMacAddress();
                //var destination = sockIp + ":" + sockPort;
                var destination = String.Empty;
                var adminUser = "STA-20101-Tobi";
                var transactionId = "01.00.1209387817.31.0035133522.POS-12/234.1782096210243";
                //var methodCall = "DEPOSIT";
                var senderIpAddress = MethodManager.GetIpAddress();
                //var senderMacAdd = GetMacAddress;
                var userId = 100;
                decimal latitude = (decimal)7.1023; //read latitude from machine profile
                decimal longitude = (decimal)6.5093; //read longitude from machine profile
                var screen = "777"; //read screen from screen manager
                var state = "2"; //read state from screen manager
                var description = "Deposit Information";
                var contentType = "whatever";
                var notes = "This is a deposit message";
                var amount = txtTotalCounted.Text;
                var accountNum = "1234Account";


                try
                {
                    var accept = Gctrl.DoGlyDeStore(handle);
                    if (!accept.Contains("ERROR"))
                    {
                        //Deposit Infomation

                        //instantiate PiarOutput for deposit
                        var depositParams = new List<Common.PairOutput>();
                        var param0 = new Common.PairOutput
                        {
                            Text = "TransactionId",
                            Value = transactionId
                        };
                        var param1 = new Common.PairOutput
                        {
                            Text = "Amount",
                            Value = amount
                        };
                        var param2 = new Common.PairOutput
                        {
                            Text = "AcctNo",
                            Value = accountNum
                        };

                        var param3 = new Common.PairOutput
                        {
                            Text = "Currency",
                            Value = "NGN"
                        };
                        var param4 = new Common.PairOutput
                        {
                            Text = "Depositor",
                            Value = "Yames"
                        };
                        var param5 = new Common.PairOutput
                        {
                            Text = "SessionId",
                            Value = "1"
                        };
                        depositParams.Add(param0);
                        depositParams.Add(param1);
                        depositParams.Add(param2);
                        depositParams.Add(param3);
                        depositParams.Add(param4);
                        depositParams.Add(param5);

                        //depositContent.Parameters = depositParams;
                        var depositContent = new Content
                        {
                            MethodCall = "DEPOSIT",
                            Parameters = depositParams
                        };


                        TransactionCls.MethodContent = depositContent;
                        var msg = MethodManager.DoMethod(messageType, origin, destination, adminUser, transactionId, senderIpAddress, userId, longitude, latitude, screen, state, description, contentType, notes, amount, accountNum);
                        if (msg == "1")
                        {
                            TransactionFrm win = new TransactionFrm
                            {
                                Topmost = true,
                                WindowStyle = WindowStyle.None,
                                WindowState = WindowState.Maximized
                            };

                            //close glory handle
                            Gctrl.DoGloryClose(_handle);
                            _handle = "";
                            _handle = null;
                            //call glory method to clear handle from device memory
                            Gctrl.DoClearDeviceHandle(_handle);

                            this.Close();
                            win.ShowDialog();

                        }
                        // MessageBox.Show(msg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }



        #endregion machine methods ends


    }
}
