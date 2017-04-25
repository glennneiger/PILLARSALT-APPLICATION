using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PILLARSALT_KIOSK.AppCodes
{
    public class Log
    {

        private int _errorType;

        public int ErrorType
        {
            get { return _errorType; }
            set { _errorType = value; }
        }


        private string _source;

        public string Source
        {

            get { return _source; }

            set { _source = value; }
        }

        private string _dmodule;

        public string DModule
        {
            get { return _dmodule; }
            set { _dmodule = value; }
        }

        private string _method;

        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }

        private string _stack;

        public string Stack
        {
            get { return _stack; }
            set { _stack = value; }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        private string _otherInfo;

        public string OtherInfo
        {
            get { return _otherInfo; }
            set { _otherInfo = value; }
        }

        private string _userid;

        public string UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private System.DateTime _entry;

        public System.DateTime Entry
        {
            get { return _entry; }
            set { _entry = value; }
        }

        private string _browserType;

        public string BrowserType
        {
            get { return _browserType; }
            set { _browserType = value; }
        }

        private string _userAgent;

        public string UserAgent
        {
            get { return _userAgent; }
            set { _userAgent = value; }
        }

        private bool _isMobile;

        public bool IsMobile
        {
            get { return _isMobile; }
            set { _isMobile = value; }
        }

        private string _mobileDevice;

        public string MobileDevice
        {
            get { return _mobileDevice; }
            set { _mobileDevice = value; }
        }

    }
}