using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxGLORYCOCTRLLib;
using GLORYCOCTRLLib;

namespace GloryWindowsUserControl
{
    public partial class GloryWinUserControl : UserControl
    {
        AxGloryCoCtrl axGloryCoCtrl1 = new AxGloryCoCtrl();


        public GloryWinUserControl()
        {
            InitializeComponent();
        }

        private void GloryWinUserControl_Load(object sender, EventArgs e)
        {

        }

        public string DoGloryOpen(string handleName)
        {
            try
            {
                if (!axGloryCoCtrl1.Created)
                {
                    axGloryCoCtrl1.CreateControl();
                    return axGloryCoCtrl1.GlyOpen(handleName);
                }
                return axGloryCoCtrl1.GlyOpen(handleName);
            }
            catch (Exception ex)
            {
                return "Unable to create open operation : " + ex.Message;
            }

        }

        public string DoGloryClose(string handleName)
        {
            try
            {
                if (!axGloryCoCtrl1.Created)
                {
                    axGloryCoCtrl1.CreateControl();
                    return axGloryCoCtrl1.GlyClose(handleName);
                }
                return axGloryCoCtrl1.GlyClose(handleName);
            }
            catch (Exception ex)
            {
                return "Unable to create close operation : " + ex.Message;
            }

        }

        public string DoGlyDeLock(string handleName)
        {
            try
            {
                string deLock = null;
                if (!axGloryCoCtrl1.Created)
                {
                    axGloryCoCtrl1.CreateControl();
                    deLock = axGloryCoCtrl1.GlyDeLock(handleName);
                }
                deLock = axGloryCoCtrl1.GlyDeLock(handleName);

                return deLock;
            }
            catch (Exception ex)
            {
                return "DeLock failed : " + ex.Message;
            }

        }

        public string DoGlyAsyncDeCntStart(string handle)
        {
            try
            {
                string rtn = String.Empty;
                if (!axGloryCoCtrl1.Created)
                {
                    axGloryCoCtrl1.CreateControl();
                    rtn = axGloryCoCtrl1.GlyAsyncDeCntStart(handle);
                }

                rtn = axGloryCoCtrl1.GlyAsyncDeCntStart(handle);
                return rtn;
            }
            catch (Exception ex)
            {
                return "Error : CntStart failed : " + ex.Message;
            }
        }

        public string DoOpenEscrow(string handleName)
        {
            try
            {
                string rtn = String.Empty;
                if (!axGloryCoCtrl1.Created)
                {
                    axGloryCoCtrl1.CreateControl();
                    rtn = axGloryCoCtrl1.GlyDeCancel(handleName);
                }
                rtn = axGloryCoCtrl1.GlyDeCancel(handleName);
                return rtn;

            }
            catch (Exception ex)
            {
                return "Error : Open Escrow Failed : " + ex.Message;
            }

        }

        public string DoCountData()
        {
            if (!axGloryCoCtrl1.Created)
            {
                axGloryCoCtrl1.CreateControl();
                return axGloryCoCtrl1.CountData; ;
            }
            return axGloryCoCtrl1.CountData;
        }

        public string DoGlyReadLog(string handle)
        {
            if (!axGloryCoCtrl1.Created)
            {
                axGloryCoCtrl1.CreateControl();
                return axGloryCoCtrl1.GlyAsyncLogRead(handle); ;
            }
            return axGloryCoCtrl1.GlyAsyncLogRead(handle);
        }

        public string DoGlyDeStore(string handle)
        {

            return null;
        }

        public void DoClearDeviceHandle(string mHandle)
        {


        }

        public string GetDepositFixEvent(string mHandle)
        {
            try
            {
                string rtn = String.Empty;
                if (!axGloryCoCtrl1.Created)
                {
                    axGloryCoCtrl1.CreateControl();
                    rtn = axGloryCoCtrl1.GlyDepositFixEvent(mHandle);
                }
                rtn = axGloryCoCtrl1.GlyAsyncLogRead(mHandle);
                return rtn;
            }
            catch (Exception ex)
            {
                return "Error : DepositFixEvent Failed : " + ex.Message;
            }
        }

        public string GetProcessorStatus(string mHandle)
        {
            try
            {
                string rtn = String.Empty;
                if (!axGloryCoCtrl1.Created)
                {
                    axGloryCoCtrl1.CreateControl();
                    rtn = axGloryCoCtrl1.GlyDeGetStatus(mHandle);
                }
                rtn = axGloryCoCtrl1.GlyDeGetStatus(mHandle);
                return rtn;
            }
            catch (Exception ex)
            {
                return "Error : ProcessorStatus Failed : " + ex.Message;
            }
        }




    }
}
