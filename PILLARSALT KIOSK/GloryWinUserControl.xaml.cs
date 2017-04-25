using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using AxGLORYCOCTRLLib;

//using Glory

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for GloryWinUserControl.xaml
    /// </summary>
    public partial class GloryWinUserControl : UserControl
    {
        readonly AxGloryCoCtrl _axGloryCoCtrl1 = new AxGloryCoCtrl();
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
                if (!_axGloryCoCtrl1.Created)
                {
                    _axGloryCoCtrl1.CreateControl();
                    return _axGloryCoCtrl1.GlyOpen(handleName);
                }
                return _axGloryCoCtrl1.GlyOpen(handleName);
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
                if (!_axGloryCoCtrl1.Created)
                {
                    _axGloryCoCtrl1.CreateControl();
                    return _axGloryCoCtrl1.GlyClose(handleName);
                }
                return _axGloryCoCtrl1.GlyClose(handleName);
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
                Task t = Task.Run(() =>
                {
                    if (!_axGloryCoCtrl1.Created)
                    {
                        _axGloryCoCtrl1.CreateControl();
                        deLock = _axGloryCoCtrl1.GlyDeLock(handleName);
                    }
                    deLock = _axGloryCoCtrl1.GlyDeLock(handleName);
                });
                t.Wait(5000);
                return deLock;
            }
            catch (Exception ex)
            {
                return "DeLock failed : " + ex.Message;
            }

        }

        public string DoGlyAsyncDeCntStart(string handle)
        {
            if (!_axGloryCoCtrl1.Created)
            {
                _axGloryCoCtrl1.CreateControl();
                return _axGloryCoCtrl1.GlyAsyncDeCntStart(handle);
            }
            return _axGloryCoCtrl1.GlyAsyncDeCntStart(handle);
        }

        public string DoCountData()
        {

            return null;
        }

        public string DoGlyDeStore(string handle)
        {

            return null;
        }

        public void DoClearDeviceHandle(string handle)
        {
            throw new NotImplementedException();
        }
    }
}
