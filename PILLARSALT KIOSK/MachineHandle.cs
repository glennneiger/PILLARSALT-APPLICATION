using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using GloryWindowsUserControl;
using PILLARSALT_KIOSK.AppCodes;
using SocketLibrary;

namespace PILLARSALT_KIOSK
{
    public static class MachineHandle
    {
        public static string MHandle { get; set; }
        public static DataSet CountDataSet;
        public static DataTable CountDataTable;
        public static Content Content1 { get; set; }
        public static string ReceiverAccountNumber { get; set; }
        public static string DepositorPhoneNumber { get; set; }

        public static decimal TotalAmountCounted = 0.00M;
        public static string _countDataArr;
        public static string _rtnCountData;
        public static decimal _totalAmount = 0.00M;

        public static GloryWinUserControl Gctrl = new GloryWinUserControl();

        #region machine methods begins 
        public static void DoStoreForRetailer()
        {
            var messageType = "KIOSK-REQUEST";
            var origin = MethodManager.GetMacAddress();
            var destination = String.Empty;
            var adminUser = "STA-20101-TOBI";
            var transactionId = "01.00.1209387817.31.0035133522.POS-12/234.1782096210243";
            var senderIpAddress = MethodManager.GetIpAddress();
            var userId = 100;
            decimal latitude = (decimal)7.1023; //read latitude from machine profile
            decimal longitude = (decimal)6.5093; //read longitude from machine profile
            var screen = "777"; //read screen from screen manager
            var state = "2"; //read state from screen manager
            var description = "Deposit Information";
            var contentType = "Deposit Transaction Type";
            var notes = "This is a deposit message";
            var amount = _totalAmount;
            var depositorPhoneNumber = DepositorPhoneNumber;
            var accountNum = "1234Account";

            try
            {
                var accept = Gctrl.DoGlyDeStore(MHandle);
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
                        Value = Convert.ToString(_totalAmount, CultureInfo.CurrentCulture)
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

                    List<Common.PairOutput> denParams = new List<Common.PairOutput>();
                    foreach (DataRow row in CountDataTable.Rows)
                    {
                        Common.PairOutput den = new Common.PairOutput
                        {
                            Text = row[0].ToString(),
                            Value = row[1].ToString()
                        };
                        denParams.Add(den);
                    }
                    //denomContent Parameters
                    var denomContent = new Content
                    {
                        MethodCall = "DENOMINATION",
                        Parameters = denParams
                    };
                    TransactionCls.DenominationContents = denomContent;
                    TransactionCls.MethodContent = depositContent;

                    var msg = MethodManager.DoMethod(messageType, origin, destination, adminUser, transactionId, senderIpAddress, userId, longitude, latitude, screen, state, description, contentType, notes, _totalAmount.ToString(CultureInfo.CurrentCulture), accountNum);
                    if (msg == "1")
                    {

                    }
                    MessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //}
        }

        public static string DoRejectOpenEscrow()
        {
            var s = Gctrl.DoOpenEscrow(MHandle);
            return s;

        }


        public static int OpenGloryOnLoad()
        {
            //start glory
            //open glory again to recount
            MHandle = String.Empty;

            if (string.IsNullOrEmpty(MHandle))
            {
                var rtn = Gctrl.DoGloryOpen("DLLTEST");

                var words = rtn.Split(',');
                MHandle = words[1];
                //MessageBox.Show("Handle is --- " + MHandle);
                return 1;
            }
            return 0;
        }

        public static void DoCloseGlory()
        {
            //close glory handle
            var s = Gctrl.DoGloryClose(MHandle);
            if (!s.Contains("Errror"))
            {
                //MessageBox.Show("Glory Closed!");
                MHandle = String.Empty;
            }

        }

        public static string DoGlyAsyncDeLock(string mHandle)
        {
            return Gctrl.DoGlyAsyncDeLock(mHandle);
        }

        public static string DoGlyAsyncDeUnLock(string mHandle)
        {
            return Gctrl.DoGlyAsyncDeUnLock(mHandle);
        }

        public static string DoCountData()
        {
            return Gctrl.DoCountData();
        }

        public static async Task<string> DoGlyAsyncDeCntStart(string mHandle)
        {
            return await Task.Run(() => Gctrl.DoGlyAsyncDeCntStart(mHandle));
        }

        public static string GetEscrowStatus()
        {
            return Gctrl.GetEscrowStatus(MHandle);
        }

      
        #endregion
    }
}