using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
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

        #region machine methods begins 
        public static Content Content1 { get; set; }
        public static GloryWinUserControl Gctrl = new GloryWinUserControl();

        public static DataTable DoStartCount()
        {
            MessageBox.Show("Do start");

            try
            {
                //start glory
                //open glory again to recount
                MHandle = String.Empty;

                if (string.IsNullOrEmpty(MHandle))
                {
                    var rtn = Gctrl.DoGloryOpen("DLLTEST");
                    var words = rtn.Split(',');
                    MHandle = words[1];
                    MessageBox.Show("Handle is --- " + MHandle);
                }

                //skip delock
                goto countStart;

                deLock: //call method to delock glory if error occur in glory
                Gctrl.DoGlyDeLock(MHandle);

                countStart:
                //Do count start Delay 1 seconds
                Thread.Sleep(1000);
                var rtnCntStart = Gctrl.DoGlyAsyncDeCntStart(MHandle);
                if (rtnCntStart.Contains("ERROR"))
                {
                    goto deLock;
                }

                //Delay 1 seconds
                Thread.Sleep(1000);
                var rtnCountData = Gctrl.DoCountData();

                MessageBox.Show(rtnCountData);
                if (!rtnCountData.Contains("ERROR") && rtnCountData != "")
                {
                    //remove first part of string from the returned string
                    var countData = rtnCountData.Split(':');
                    //create array from the second part of returned string
                    var countDataArr = countData[1];
                    var primeArray = countDataArr.Split(',');

                    //prepare datatable for the array elements
                    CountDataSet = new DataSet();
                    CountDataTable = new DataTable();

                    CountDataTable.Columns.Add("NOTE");
                    CountDataTable.Columns.Add("QUANTITY");
                    CountDataTable.Columns.Add("TOTAL");

                    for (int i = 0; i < primeArray.Length; i += 5)
                    {
                        int first = Convert.ToInt16(primeArray[i]);
                        int second = Convert.ToInt16(primeArray[i + 1]);
                        int third = first * second;
                        if (second != 0)
                        {
                            CountDataTable.Rows.Add(first, second, third);
                        }
                    }
                    CountDataSet.Tables.Add(CountDataTable);
                    return CountDataTable;
                }

                //Delay 2 seconds
                Thread.Sleep(2000);
                goto deLock;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public static void DoStoreForRetailer(string dAmount)
        {
            var messageType = "KIOSK-REQUEST";
            var origin = MethodManager.GetMacAddress();
            var destination = String.Empty;
            var adminUser = "STA-20101-Tobi";
            var transactionId = "01.00.1209387817.31.0035133522.POS-12/234.1782096210243";
            var senderIpAddress = MethodManager.GetIpAddress();
            var userId = 100;
            decimal latitude = (decimal)7.1023; //read latitude from machine profile
            decimal longitude = (decimal)6.5093; //read longitude from machine profile
            var screen = "777"; //read screen from screen manager
            var state = "2"; //read state from screen manager
            var description = "Deposit Information";
            var contentType = "whatever";
            var notes = "This is a deposit message";
            //var amount = dAmount;
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
                        Value = dAmount
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

                    var msg = MethodManager.DoMethod(messageType, origin, destination, adminUser, transactionId, senderIpAddress, userId, longitude, latitude, screen, state, description, contentType, notes, dAmount, accountNum);
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
        #endregion

        public static void DoCloseGlory()
        {
            //close glory handle
            var s = Gctrl.DoGloryClose(MHandle);
            if (!s.Contains("Errror"))
            {
                MessageBox.Show("Glory Closed!");
                MHandle = String.Empty;
            }

        }
    }
}