using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;
using System.Xml.Serialization;
using SocketLibrary;
//using System.Windows.Forms;

namespace PILLARSALT_KIOSK.AppCodes
{
    public static class MethodManager
    {
        public static string RtnMessage = null;
        private static PilaDbContext _db;

        public static string DoMethod(string messageType, string origin, string destination, string adminuser, string transactionId, string senderIpAdd, int userId, decimal longitud, decimal latitude, string screen, string state, string description, string contentType, string notes, string amount, string accountNo)
        {
            try
            {
                _db = new PilaDbContext();
                ConnectionInfo profInfo = _db.ConnectionInfoes.First(c => c.Active == 1);
                if (profInfo != null)
                {
                    //instantiate Message Headers
                    MessageHeader mHeader = new MessageHeader
                    {
                        MessageType = messageType,
                        Origin = GetMacAddress(),
                        Destination = profInfo.IPAddress + ":" + profInfo.SocketPort,
                        AdminUser = adminuser,
                        TransactionCode = transactionId
                    };


                    //instantiate Message Trail
                    MessageTrail mTrail = new MessageTrail
                    {
                        IPAddress = senderIpAdd,
                        MAC = GetMacAddress(),
                        SentDate = DateTime.Now,
                        UserId = userId,
                        Latitude = latitude,
                        Longitude = longitud,
                        Screen = screen,
                        State = state
                    };

                    var allContents = new List<Content>();
                    //Add deposit content
                    allContents.Add(TransactionCls.MethodContent);

                    ////Add denomination content
                    //allContents.Add(TransactionCls.DenominationContents);


                    //instantiate Message content
                    MessageContent mContent = new MessageContent
                    {
                        IsEncryted = true,
                        Description = description,
                        ContentType = contentType,
                        Contents = allContents
                    };

                    //instantiate PillarSaltMessage content
                    PillarSaltMessage p = new PillarSaltMessage
                    {
                        Notes = notes,
                        Header = mHeader,
                        content = mContent,
                        Trails = mTrail
                    };

                    XmlSerializer x = new XmlSerializer(p.GetType());
                    var strWriter = new StringWriter();
                    TextWriter tw = new StreamWriter(@"C:\\Machine\\DepositeMessage.xml");

                    x.Serialize(tw, p);
                    x.Serialize(strWriter, p);

                    var encryptedMessage = EncryptMessageFromkiosk(strWriter.ToString()).Notes;
                    TMSSocketClient sending = new TMSSocketClient();
                    ConnectionInfo profile = _db.ConnectionInfoes.First(c => c.Active == 1);
                    if (profile != null)
                    {
                        var response = sending.SyncClient(profile.IPAddress, Convert.ToInt32(profile.SocketPort), encryptedMessage);
                        var decryptedResponse = DecryptMessageFromTms(response.Notes);

                        RtnMessage = decryptedResponse.Value;
                        MessageBox.Show(RtnMessage);
                        return RtnMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                RtnMessage = "ERROR : " + ex.Message;
                MessageBox.Show(RtnMessage);

            }
            return RtnMessage;
        }

        private static Common.Output DecryptMessageFromTms(string notes)
        {
            try
            {
                _db = new PilaDbContext();
                ConnectionInfo profile = _db.ConnectionInfoes.First(c => c.Active == 1);
                var keyData = profile.PrivateKey;
                KeyManager keyM = new KeyManager();
                var decrypted = keyM.DecryptPGP(profile.KeyName, profile.KeyName, profile.KeyPass, notes, keyData);
                if (decrypted.Value == "0")
                {
                    return new Common.Output("FAILED", "0", DateTime.Now, false, "Encryption Error : " + decrypted.Notes);
                }
                return new Common.Output("SUCCESS", "1", DateTime.Now, true, decrypted.Notes);

            }
            catch (Exception ex)
            {
                return new Common.Output("FAILED", "0", DateTime.Now, false, "Encryption Error : " + ex.Message);
            }
        }

        private static Common.Output EncryptMessageFromkiosk(string message)
        {
            try
            {
                _db = new PilaDbContext();
                ConnectionInfo profile = _db.ConnectionInfoes.First(c => c.Active == 1);
                if (profile != null)
                {
                    var keyValue = Encoding.ASCII.GetString(profile.PublicKey);
                    KeyManager keyM = new KeyManager();
                    var encrypted = keyM.EncryptPGP(profile.KeyName, profile.KeyName, profile.KeyPass, message,
                        profile.PublicKey);
                    if (!string.IsNullOrEmpty(encrypted.Value = "0"))
                    {
                        return new Common.Output("FAILED", "0", DateTime.Now, false, "Encryption Error : " + encrypted.Notes);
                    }
                    return new Common.Output("SUCCESS", "1", DateTime.Now, true, encrypted.Notes);

                }
                return new Common.Output("HALTED", "0", DateTime.Now, false, "PROFILING ERROR ");
            }
            catch (Exception ex)
            {
                return new Common.Output("FAILED", "0", DateTime.Now, false, "Encryption Error : " + ex.Message);
            }

        }


        public static PillarSaltMessage UnencryptedParser(string decryptedXML)
        {
            PillarSaltMessage myObject = default(PillarSaltMessage);
            XmlSerializer mySerializer = new XmlSerializer(typeof(PillarSaltMessage));
            // convert string to stream
            byte[] byteArray = Encoding.Unicode.GetBytes(decryptedXML);
            MemoryStream stream = new MemoryStream(byteArray);
            // Call the Deserialize method and cast to the object type.
            myObject = (PillarSaltMessage)mySerializer.Deserialize(stream);

            //Dim dNotes = myObject.content.Contents(0).MethodCall
            //Console.WriteLine(dNotes)
            return myObject;

        }

        public static string GetIpAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            var sIpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            return sIpAddress;
        }
        public static string GetMacAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        public static void DoAppLog(int errorType, string source, string dModule, string method, string stack, string errorMessage, string otherInfo)
        {
            //string status = null;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //check if errorLog dat exist
            List<Log> errLogs = new List<Log>();
            errLogs.Add(new Log
            {
                ErrorType = errorType,
                Source = source,
                ErrorMessage = errorMessage,
                DModule = dModule,
                Method = method,
                OtherInfo = otherInfo,
                Stack = stack,

            });

            //TextWriter twr;
            dynamic logs = serializer.Serialize(errLogs);
            const string dFolder = @"C:\KioskLog";
            Directory.CreateDirectory(dFolder);

            string path = dFolder + @"\Applog.txt";

            using (StreamWriter w = File.AppendText(path))
            {
                Log(logs.ToString(), w);
                //Log("Test2", w);
            }

            using (StreamReader r = File.OpenText(path))
            {
                DumpLog(r);
            }

        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine("  :{0}", logMessage);
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
