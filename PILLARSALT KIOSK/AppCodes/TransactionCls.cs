using System;
using System.Collections.Generic;
using SocketLibrary;

//using static PILLARSALTKIOSK.Screen004;

namespace PILLARSALT_KIOSK.AppCodes
{
    public static class TransactionCls
    {
        public static string MethodId { get; set; }
        public static string TransactionId { get; set; }
        public static string AccountNo { get; set; }
        public static string Amount { get; set; }
        public static string Currency { get; set; }
        public static string Depositor { get; set; }
        public static string Quantity { get; set; }
        public static string Value { get; set; }
        public static string BankName { get; set; }
        public static string FinCode { get; set; }
        public static DateTime TransactionDt { get; set; }
        public static string PhoneNumber { get; set; }
        public static Content MethodContent { get; set; }
        public static Content DenominationContents { get; set; }


    }
}
