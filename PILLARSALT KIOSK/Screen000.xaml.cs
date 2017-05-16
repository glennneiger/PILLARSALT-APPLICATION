using System;
using System.IO.Ports;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Media;
using PILLARSALT_KIOSK.AppCodes;
using ThermalDotNet;

namespace PILLARSALT_KIOSK
{
    /// <summary>
    /// Interaction logic for Screen000.xaml
    /// </summary>
    public partial class Screen000 : Window
    {
        public Screen000()
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;
            //printer setup
            //SetupPrinter();

            //play media
            PlayAdvert();
        }

        static string _printerPortName = "COM1";
        static SerialPort serialPort = new SerialPort(_printerPortName, 9600);
        //static ThermalPrinter printer = new ThermalPrinter(serialPort, 2, 180, 2);

        //public static int SetupPrinter()
        //{
        //    try
        //    {
        //       printer.WakeUp();
        //        MessageBox.Show(printer.ToString());

        //        if (serialPort != null)
        //        {
        //            //checkPrinter:
        //            MessageBox.Show("Port ok");
        //            if (serialPort.IsOpen)
        //            {
        //                serialPort.Open();
        //                MessageBox.Show("Port Open");
        //                //serialPort.Close();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Port Closed");
        //                //goto checkPrinter;
        //            }
        //        }
        //        //MessageBox.Show("Opening port");
        //        //serialPort.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("I/O error : " + ex.Message);
        //        Environment.Exit(0);
        //    }


        //    return 0;
        //}


        //declarations

        public MediaPlayer Player;
        //public WindowsMediaPlayer MPlayer;
        public ScreenManager Sm;
        private ThermalPrinterClass _thermal;
        private ThermalPrinter _printer;

        public void PlayAdvert()
        {
            Player = new MediaPlayer();
            Player.Open(new Uri(@"c:\\KioskVideo\\1.mp4", UriKind.Relative));
            VideoDrawing drawing = new VideoDrawing
            {
                Rect = new Rect(0, 0, 1000, 600),
                Player = Player
            };
            Player.Play();
            DrawingBrush brush = new DrawingBrush(drawing);
            Background = brush;
        }
        private void GotoLanguagePage(object sender, RoutedEventArgs e)
        {
            MethodManager.DoAppLog(0, "Screen000", "", "GotoMenu", MethodManager.GetMacAddress(), "", "");

            string screenName = "Screen001";
            Sm = new ScreenManager();
            string pScreen = this.Name;
            Array stateArr = Sm.GetStateArray();

            ShowNextWindow(screenName);

            this.Hide();
            Player.Pause();
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var window = (Window)Application.LoadComponent(new Uri("SetIpFrm.xaml", UriKind.Relative));
            window.Topmost = true;
            window.Owner = this;
            window.ShowDialog();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

            _thermal = new ThermalPrinterClass();
            _thermal.TestReceipt(_printer);
            //MyPrinter.PrintReceiptForTransaction();
            //MyPrinter.PrintRawData();

        }
        
        private void OpenGloryOnLoad(object sender, RoutedEventArgs e)
        {
            int o = MachineHandle.OpenGloryOnLoad();
            if (o < 1)
            {
                Environment.Exit(0);
            }
            else
            {
                //MessageBox.Show("Glory Open!");
            }
            
        }
    }
}
