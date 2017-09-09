using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HL7
{

    public class Server
    {
        private TcpListener _tcpListener;
        private Thread _listenThread;
        //    public static HL7Message.MSH msh = new HL7Message.MSH();
        public static HL7Message.ORC orc = new HL7Message.ORC();
        public static HL7.DBProcess InsWrklst = new HL7.DBProcess();
        //   public static HL7Message.PID pid = new HL7Message.PID();
        //   public static HL7Message.PV1 pv1 = new HL7Message.PV1();
        //   public static HL7Message.AL1 al1 = new HL7Message.AL1();
        public string bodymessage;
        public string konu = "Girilmesi ZOrunlu Alanlar";
        public string kimden="nurcurukoglu@gmail.com";
        public string kime = "nurcurukoglu@gmail.com";
        public static HL7.MailSender MailSender = new HL7.MailSender();
        //int port;

        public Server()
        {

        }
        public void CloseAllConnection()
        {
            _listenThread.Abort();
            _tcpListener.Stop();
            _tcpListener = null;

        }


        public void StartConnection()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Any, 8888); //benim ip mi buluyor.
                _listenThread = new Thread(new ThreadStart(ListenForClients)); //yeni bir thread oluşturuyor.ListenForClients a gönderiyor.

                _listenThread.Start(); //thread başlıyor.

            }
            catch (Exception Hata)
            {

            }
        }

        private void ListenForClients()  //TCP burda açılıyor.Bu şekilde olmasının nedeni aynı anda birden fazla port dinleyebiliriz.
        {
            try
            {
                _tcpListener.Start(); //TCP dinlenmeye başlıyor.

                while (true) //eğer TCP dinleniyorsa(true ise) clientten gelen mesajları kabul ediyor.
                {
                    TcpClient client = _tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm)); //gelen mesajları yeni bir thread a yönlendiriyor.

                    clientThread.Start(client); //thread başlıyor.

                }
            }
            catch (Exception Hata)
            {

            }
        }



        private void HandleClientComm(object client) //clienttan gelen mesajları burada alıyor.Okuyor.
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            StreamWriter sw = new StreamWriter(clientStream);

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
                message = new byte[4096];
                try
                {

                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch (Exception Err)
                {

                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                Encoding encoder = Encoding.UTF8;
                string str = encoder.GetString(message, 0, bytesRead); //gelen mesajı stringe çeviriyor.
               
                if (str.Contains("ORU^R01"))
                {
                    var oru_r01 = new ORU_R01(str);


                    //   oru_r01.Parse(str);

                    //string MSH = str.Substring(0, (str.IndexOf("PID") - 0)); //ilk elemandan PID ye kadar olan kısmı alır.

                    //if (MSH.Substring(1, 3) == "MSH") //MSH ın 1.indexinden sonra 3 char kontrolünü yapıyor.
                    //{
                    //    msh.Parse(MSH);
                    //    msh.save();
                    //}

                    //int a = str.IndexOf("PID"); //PID nin kaçıncı indexte olduğunu gösteriyor.

                    //string PID = str.Substring(a, (str.IndexOf("PV1") - a)); //PID nin başladığı yerden PV1 in bittiği yere kadar olan kısmı alıyor.

                    //if (PID.Substring(0, 3) == "PID") //PID stringinin ilk 3 karakterini kontrol ediyor.
                    //{
                    //    pid.Parse(PID);
                    //    pid.Save();
                    //}

                    //int b = str.IndexOf("PV1"); //PV1 in hangi indexte olduğunu buluyor.

                    //string PV1 = str.Substring(b, (str.IndexOf("AL1") - b)); //PV1 in başladığı yerden ORC nin bittiği yere kadar olan kısım 

                    //if (PV1.Substring(0, 3) == "PV1")
                    //{
                    //    pv1.Parse(PV1);
                    //    pv1.Save();
                    //}

                    //int c = str.IndexOf("AL1"); //AL1 in hangi indexte olduğunu buluyor.

                    //string AL1 = str.Substring(c, (str.IndexOf("ORC") - c));

                    //if (AL1.Substring(0, 3) == "AL1")
                    //{
                    //    al1.Parse(AL1);
                    //    al1.Save();
                    //}

                    //int i = str.IndexOf("ORC");  //ORC nin kaçıncı indexte olduğunu gösteriyor.
                    //string ORC = str.Substring(i); //str stringinin i. indexten sonrasını alıyor.

                    //if (ORC.Substring(0, 3) == "ORC")
                    //{
                    //    orc.Parse(ORC);
                    //    orc.save();
                    //}
                    if (oru_r01.ORC.Order_Control == "NW")
                    {
                        WorkList wrklst = new WorkList();

                        wrklst.Status =null;
                        if (oru_r01.PID.Patient_Name != "" )
                        {
                            wrklst.patname = oru_r01.PID.Patient_Name;
                        }
                        else
                        {
                            bodymessage= bodymessage + "Hasta ismi boş olamaz" + "/n";
                        }
                        if (oru_r01.PID.Patient_ID!="")
                        {
                            wrklst.patid = oru_r01.PID.Patient_ID;
                        }
                        else
                        {
                            bodymessage = bodymessage + "Hasta ID girilmek zorundadır." + "/n";
                        }
                       
                        wrklst.patotherid = oru_r01.PID.Alternate_Patient_ID;
                        wrklst.patbirthdate = oru_r01.PID.Date_Time_Of_Birth;
                        wrklst.patbirthtime = oru_r01.PID.Date_Time_Of_Birth;
                        wrklst.patsex = oru_r01.PID.Sex;
                        wrklst.pataddresse = oru_r01.PID.Patient_Address;
                        wrklst.patmedicalalerts = oru_r01.OBR.Relevant_Clinical_Info;
                        wrklst.patethnicgroup = oru_r01.PID.Race;
                        if (oru_r01.AL1.Allergy_Code_Mnemonic_Description!="")
                        {
                            wrklst.patcontrastallergies = oru_r01.AL1.Allergy_Code_Mnemonic_Description;
                        }
                        else
                        {
                            bodymessage = bodymessage + "Hastanın alerji durumunu belirtiniz." + "/n";
                        }
                        wrklst.patpregnancystatus = oru_r01.PV1.Ambulatory_Status;
                        wrklst.patcomments = oru_r01.NTE.Comment;
                        wrklst.patstate = oru_r01.OBR.Danger_Code;
                        wrklst.patconfidentialconstraint = oru_r01.PV1.VIP_Indicator;
                        wrklst.accessionnumber = oru_r01.OBR.Placer_Field_1;
                        wrklst.referringpysician = oru_r01.PV1.Referring_Doctor;
                        wrklst.requestingphysician = oru_r01.OBR.Ordering_Provider;
                        wrklst.sstationaetitle = oru_r01.OBR.Filler_Field_2;
                        wrklst.spstartdate = oru_r01.OBR.Quantity_Timing;
                        wrklst.spstarttime = oru_r01.OBR.Quantity_Timing;
                        wrklst.modatity = oru_r01.OBR.Diagnostic_Serv_Sect_ID;
                        wrklst.sperformingphysician = oru_r01.OBR.Technician;
                        wrklst.spstepid = oru_r01.OBR.Filler_Field_1;
                        wrklst.requestedprocedureid = oru_r01.OBR.Placer_Field_2;
                        wrklst.proceduredescription = oru_r01.OBR.Ordering_Provider;
                        // wrklst.studyinstanceuid=ZDS tablosu yok.
                        wrklst.patienttransportarrangements = oru_r01.OBR.Transportation_Mode;
                        wrklst.currentlocation = oru_r01.PV1.Assigned_Patient_Location;
                        wrklst.admissionid = oru_r01.PID.Patient_Account_Number;

                        if (bodymessage==null)
                        {
                            string donus = InsWrklst.InsertWorkList(wrklst);
                        }
                        else
                        {
                            MailSender.Sent(kimden, kime, konu, bodymessage);
                        }
                    

                    }
                }
            }
            sw.Dispose();
            clientStream.Dispose();
            tcpClient.Close();

        }

        private string trktoeng(string txt)
        {
            txt = txt.Replace('Ş', 'S');
            txt = txt.Replace('Ç', 'C');
            txt = txt.Replace('İ', 'I');
            txt = txt.Replace('Ö', 'O');
            txt = txt.Replace('Ü', 'U');
            txt = txt.Replace('Ğ', 'G');

            txt = txt.Replace('ş', 's');
            txt = txt.Replace('ç', 'c');
            txt = txt.Replace('ı', 'i');
            txt = txt.Replace('ö', 'o');
            txt = txt.Replace('ü', 'u');
            txt = txt.Replace('ğ', 'g');
            return txt;

        }
    }
}
