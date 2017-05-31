using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Neodynamic.SDK.Printing;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using FontStyle = System.Drawing.FontStyle;
using PrinterSettings = System.Drawing.Printing.PrinterSettings;

namespace PILLARSALT_KIOSK.AppCodes
{
    public static class MyPrinter
    {
        public static ThermalLabel _currentThermalLabel = null;

        public static void PrintReceiptForTransaction()
        {
            try
            {
                PrintDocument recordDoc = new PrintDocument();

                recordDoc.DocumentName = "Transaction Receipt!";
                recordDoc.PrintPage += new PrintPageEventHandler(PrintReceiptPage); // function below
                recordDoc.PrintController = new StandardPrintController(); // hides status dialog popup
                                                                           // Comment if debugging 
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = "POS";
                recordDoc.PrinterSettings = ps;
                recordDoc.Print();
                // --------------------------------------

                // Uncomment if debugging - shows dialog instead
                //PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
                //printPrvDlg.Document = recordDoc;
                //printPrvDlg.Width = 1200;
                //printPrvDlg.Height = 800;
                //printPrvDlg.ShowDialog();
                // --------------------------------------

                recordDoc.Dispose();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        private static void PrintReceiptPage(object sender, PrintPageEventArgs e)
        {
            float x = 10;
            float y = 5;
            float width = 270.0F; // max width I found through trial and error
            float height = 0F;

            Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;

            // Draw string to screen.
            string text = "Pillarsalt";
            e.Graphics.DrawString(text, drawFontArial12Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += e.Graphics.MeasureString(text, drawFontArial12Bold).Height;

            text = "Testing Printer!";
            e.Graphics.DrawString(text, drawFontArial10Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += e.Graphics.MeasureString(text, drawFontArial10Regular).Height;

            // ... and so on

        }

        public static void PrintText(string text)
        {
            var printDlg = new PrintDialog();
            var doc = new FlowDocument(new Paragraph(new Run(text)));
            doc.PagePadding = new Thickness(10);

            printDlg.PrintDocument((doc as IDocumentPaginatorSource).DocumentPaginator, "Print Caption");
        }



        public static void PrintViaSerialPort()
        {
            //Create a PrintJob object
            PrintJob pj = new PrintJob();
            //Thermal Printer is connected through Serial Port
            pj.PrinterSettings.Communication.CommunicationType = CommunicationType.Serial;
            //Set Thermal Printer resolution
            pj.PrinterSettings.Dpi = 203;
            //Set Thermal Printer language
            pj.PrinterSettings.ProgrammingLanguage = ProgrammingLanguage.ZPL;
            //Set Thermal Printer serial port settings 
            pj.PrinterSettings.Communication.SerialPortName = "COM1";
            pj.PrinterSettings.Communication.SerialPortBaudRate = 9600;
            pj.PrinterSettings.Communication.SerialPortDataBits = 8;
            pj.PrinterSettings.Communication.SerialPortStopBits = System.IO.Ports.StopBits.One;
            pj.PrinterSettings.Communication.SerialPortParity = System.IO.Ports.Parity.None;
            pj.PrinterSettings.Communication.SerialPortFlowControl = System.IO.Ports.Handshake.XOnXOff;


            
        }

        public static void PrintRawData()
        {
            // Send a printer-specific to the printer.
            RawPrinterHelper.SendStringToPrinter("POS", "Testing Printer");
        }


    }

    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
}
