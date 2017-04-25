using System;
using System.Threading;
using System.Windows;


namespace PILLARSALT_KIOSK.AppCodes
{
    public class ScreenManager
    {
        public string PresentScreen;
        public string BackScreen;
        public string ScreenState;
        private string _wName;

        public string GetNextScreen(string presentScreen, int mState)
        {

            int state = mState;

            switch (state)
            {
                case 0:
                    _wName = "Screen000";

                    break;
                case 1:
                    _wName = "Screen001";

                    break;
                case 2:
                    _wName = "Screen002";

                    break;
            }

           
            return _wName;
        }

        public string GetBackScreen(string presentScreen, Array screenState)
        {
            return "";
        }

        public Array GetStateArray()
        {
            Array stateArray = null;

            return stateArray;

        }
    }
}