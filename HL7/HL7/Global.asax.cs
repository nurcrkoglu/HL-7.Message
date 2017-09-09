using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace HL7
{

    public class Global : System.Web.HttpApplication //web uygulamalarının temel eventlarının kontrol edildiği yer.
    {
        Server sr = new Server();    
      //  public static HL7Message.MSH HL7 = new HL7Message.MSH();
        //TcpListener server = new TcpListener(System.Net.IPAddress.Any, 8888);

        protected void Application_Start(object sender, EventArgs e)
        {
            sr.StartConnection();
            //Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
            //thread.Start();

        }


        //public void WorkThreadFunction()
        //{
        //    try
        //    {
        //        //Start the server
        //        server.Start();
        //        TcpClient newClient = server.AcceptTcpClient();
        //        if (newClient.Available > 0) //?
        //        {
        //            //Initialzing a new byte array the size of the available bytes on the network stream
        //            byte[] readBytes = new byte[newClient.Available];
        //            //Reading data from the stream
        //            newClient.GetStream().Read(readBytes, 0, newClient.Available);
        //            //Converting the byte array to string
        //            String str = System.Text.Encoding.ASCII.GetString(readBytes);//clientten gelen veriyi byte byte okuyor.
        //            HL7.Parse(str);
        //            HL7.save();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            //server.Stop();
            
        }
    }
}