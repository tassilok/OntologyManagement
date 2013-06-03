using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ReparseElasticSearchDocs.Classes
{
    class clsNetParser
    {
        private static clsLocalConfig objLocalConfig;
        private static clsReparse objReparse;

        private Thread objTHRListen1;
        private Thread objTHRListen2;
        private Thread objTHRListen3;
        private Thread objTHRListen4;
        private Thread objTHRListen5;

        private static long lngLineCount1;
        private static long lngLineCount2;
        private static long lngLineCount3;
        private static long lngLineCount4;
        private static long lngLineCount5;

        private static int intPort1;
        private static int intPort2;
        private static int intPort3;
        private static int intPort4;
        private static int intPort5;

        private static string strContent1;
        private static string strContent2;
        private static string strContent3;
        private static string strContent4;
        private static string strContent5;

        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public long LineCount
        {
            get { return lngLineCount1 + lngLineCount2 + lngLineCount3 + lngLineCount4 + lngLineCount5; }
        }

        public long LineCount1
        {
            get { return lngLineCount1; }
        }
        public long LineCount2
        {
            get { return lngLineCount2; }
        }
        public long LineCount3
        {
            get { return lngLineCount3; }
        }
        public long LineCount4
        {
            get { return lngLineCount4; }
        }
        public long LineCount5
        {
            get { return lngLineCount5; }
        }


        public clsNetParser(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
        }

        public Boolean initialize_Parsing()
        {
            Boolean boolResult = true;

            lngLineCount1 = 0;
            lngLineCount2 = 0;
            lngLineCount3 = 0;
            lngLineCount4 = 0;
            lngLineCount5 = 0;

            
            

            objReparse = new clsReparse(objLocalConfig);
            objReparse.initialize_Reparse_NET();

            objTHRListen1 = new Thread(listen1);
            objTHRListen2 = new Thread(listen2);
            objTHRListen3 = new Thread(listen3);
            objTHRListen4 = new Thread(listen4);
            objTHRListen5 = new Thread(listen5);

            objTHRListen1.Start();
            intPort1 = objLocalConfig.Network.Ports[0];
            if (objLocalConfig.Network.Ports.Count > 1)
            {
                intPort2 = objLocalConfig.Network.Ports[1];
                objTHRListen2.Start();
                if (objLocalConfig.Network.Ports.Count > 2)
                {
                    intPort3 = objLocalConfig.Network.Ports[2];
                    objTHRListen3.Start();
                    if (objLocalConfig.Network.Ports.Count > 3)
                    {
                        intPort4 = objLocalConfig.Network.Ports[3];
                    
                        objTHRListen4.Start();
                        if (objLocalConfig.Network.Ports.Count > 4)
                        {

                            intPort5 = objLocalConfig.Network.Ports[4];
                         
                            objTHRListen5.Start();
                        }
                    }
                    
                }
            }
            
            return boolResult;
        }

        private void listen1()
        {
            ListenTcp(objLocalConfig.Network.Ports[0]);
        }

        private void listen2()
        {
            if (objLocalConfig.Network.Ports.Count>1)
            {
                ListenTcp(objLocalConfig.Network.Ports[1]);
            }
            
        }

        private void listen3()
        {
            if (objLocalConfig.Network.Ports.Count>2)
            {
                ListenTcp(objLocalConfig.Network.Ports[2]);
            }
        }

        private void listen4()
        {
            if (objLocalConfig.Network.Ports.Count > 3)
            {
                ListenTcp(objLocalConfig.Network.Ports[3]);
            }
        }

        private void listen5()
        {
            if (objLocalConfig.Network.Ports.Count > 4)
            {
                ListenTcp(objLocalConfig.Network.Ports[4]);
            }
        }

    

    public void AsynchronousSocketListener() {
    }

    public static void StartListening(int intPort) {
        // Data buffer for incoming data.
        byte[] bytes = new Byte[1024];

        // Establish the local endpoint for the socket.
        // The DNS name of the computer
        // running the listener is "host.contoso.com".
        IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
        IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, intPort);

        // Create a TCP/IP socket.
        Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp );

        // Bind the socket to the local endpoint and listen for incoming connections.
        try {
            listener.Bind(localEndPoint);
            listener.Listen(100);

            while (true) {
                // Set the event to nonsignaled state.
                allDone.Reset();

                // Start an asynchronous socket to listen for connections.
                //Console.WriteLine("Waiting for a connection...");
                /*listener.BeginAccept( 
                    new AsyncCallback(AcceptCallback),
                    listener );*/
                //AcceptStaticCallback(listener);

                // Wait until a connection is made before continuing.
                allDone.WaitOne();
            }

        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }

        //Console.WriteLine("\nPress ENTER to continue...");
        //Console.Read();
        
    }

    public static void ListenTcp(int intPort)
    {
        // Signal the main thread to continue.
        allDone.Set();

        // Get the socket that handles the client request.
        int intIx;

        TcpListener objTcpListener = new TcpListener(intPort);
        objTcpListener.Start();

        
        // Create the state object.
        StateObject state = new StateObject();
        
        /*handler.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);*/


        //intPort = ((System.Net.IPEndPoint)listener.LocalEndPoint).Port;
        TcpClient objClient = objTcpListener.AcceptTcpClient();
        NetworkStream objStream = objClient.GetStream();

        while (true)
        {
            
            int bytesRead = objStream.Read(state.buffer, 0, 4096);
            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                if (intPort == intPort1)
                {
                    strContent1 += Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead);

                    while (true)
                    {

                        intIx = startParsing(strContent1, intPort);

                        if (intIx > 0)
                        {
                            strContent1 = strContent1.Remove(0, intIx + 1);
                        }
                        else
                        {
                            break;
                        }

                    }


                }
                else if (intPort == intPort2)
                {
                    strContent2 += Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead);

                    while (true)
                    {

                        intIx = startParsing(strContent2, intPort);

                        if (intIx > 0)
                        {
                            strContent2 = strContent2.Remove(0, intIx + 1);
                        }
                        else
                        {
                            break;
                        }

                    }


                }
                else if (intPort == intPort3)
                {
                    strContent3 += Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead);


                    while (true)
                    {

                        intIx = startParsing(strContent3, intPort);

                        if (intIx > 0)
                        {
                            strContent3 = strContent3.Remove(0, intIx + 1);
                        }
                        else
                        {
                            break;
                        }

                    }


                }
                else if (intPort == intPort4)
                {
                    strContent4 += Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead);

                    while (true)
                    {

                        intIx = startParsing(strContent4, intPort);

                        if (intIx > 0)
                        {
                            strContent4 = strContent4.Remove(0, intIx + 1);
                        }
                        else
                        {
                            break;
                        }

                    }


                }
                else if (intPort == intPort5)
                {
                    strContent5 += Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead);

                    while (true)
                    {

                        intIx = startParsing(strContent5, intPort);

                        if (intIx > 0)
                        {
                            strContent5 = strContent5.Remove(0, intIx + 1);
                        }
                        else
                        {
                            break;
                        }

                    }


                }
                // Check for end-of-file tag. If it is not there, read 
                // more data.





            }
            else
            {
                objReparse.finalize_Net(intPort);
                objStream.Close();
                objClient.Close();
                objClient = objTcpListener.AcceptTcpClient();
                objStream = objClient.GetStream();

            }
        }
    }
    public static void AcceptCallback(IAsyncResult ar) {
        // Signal the main thread to continue.
        allDone.Set();

        // Get the socket that handles the client request.
        int intPort;
        int intIx;
        Socket listener = (Socket) ar.AsyncState;
        Socket handler = listener.Accept();

        // Create the state object.
        StateObject state = new StateObject();
        state.workSocket = handler;
        /*handler.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);*/

        
        intPort = ((System.Net.IPEndPoint)handler.LocalEndPoint).Port;

        while (true)
        {
            int bytesRead = handler.Receive(state.buffer);
            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                if (intPort == intPort1)
                {
                    strContent1 += Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead);

                    while (true)
                    {

                        intIx = startParsing(strContent1, intPort);

                        if (intIx > 0)
                        {
                            strContent1 = strContent1.Remove(0, intIx + 1);
                        }
                        else
                        {
                            break;
                        }

                    }

             
                }
                else if (intPort == intPort2)
                {
                    strContent2 += Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead);

                    while (true)
                    {

                        intIx = startParsing(strContent2, intPort);

                        if (intIx > 0)
                        {
                            strContent2 = strContent2.Remove(0, intIx + 1);
                        }
                        else
                        {
                            break;
                        }

                    }

             
                }
                else if (intPort == intPort3)
                {
                    strContent3 += Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead);


                    while (true)
                    {

                        intIx = startParsing(strContent3, intPort);

                        if (intIx > 0)
                        {
                            strContent3 = strContent3.Remove(0, intIx + 1);
                        }
                        else
                        {
                            break;
                        }

                    }

             
                }
                else if (intPort == intPort4)
                {
                    strContent4 += Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead);

                    while (true)
                    {

                        intIx = startParsing(strContent4, intPort);

                        if (intIx > 0)
                        {
                            strContent4 = strContent4.Remove(0, intIx + 1);
                        }
                        else
                        {
                            break;
                        }

                    }

             
                }
                else if (intPort == intPort5)
                {
                    strContent5 += Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead);

                    while (true)
                    {

                        intIx = startParsing(strContent5, intPort);

                        if (intIx > 0)
                        {
                            strContent5 = strContent5.Remove(0, intIx + 1);
                        }
                        else
                        {
                            break;
                        }

                    }

                    
                }
                // Check for end-of-file tag. If it is not there, read 
                // more data.





            }
            else
            {
                objReparse.finalize_Net(intPort);


            }
        }
    }

    public static void ReadCallback(IAsyncResult ar) {
        int intPort;
        
        // Retrieve the state object and the handler socket
        // from the asynchronous state object.
        StateObject state = (StateObject) ar.AsyncState;
        Socket handler = state.workSocket;
        int intIx;

        // Read data from the client socket. 
        int bytesRead = handler.EndReceive(ar);
        intPort = ((System.Net.IPEndPoint)handler.LocalEndPoint).Port;

        if (bytesRead > 0)
        {
            // There  might be more data, so store the data received so far.
            if (intPort == intPort1)
            {
                strContent1 += Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead);

                while (true)
                {

                    intIx = startParsing(strContent1, intPort);

                    if (intIx > 0)
                    {
                        strContent1 = strContent1.Remove(0, intIx + 1);
                    }
                    else
                    {
                        break;
                    }

                }

                if (strContent1.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    /*Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content );*/
                    // Echo the data back to the client.
                    Send(handler, strContent1);
                }
                else
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
            else if (intPort == intPort2)
            {
                strContent2 += Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead);

                while (true)
                {

                    intIx = startParsing(strContent2, intPort);

                    if (intIx > 0)
                    {
                        strContent2 = strContent2.Remove(0, intIx + 1);
                    }
                    else
                    {
                        break;
                    }

                }

                if (strContent2.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    /*Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content );*/
                    // Echo the data back to the client.
                    Send(handler, strContent2);
                }
                else
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
            else if (intPort == intPort3)
            {
                strContent3 += Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead);


                while (true)
                {

                    intIx = startParsing(strContent3, intPort);

                    if (intIx > 0)
                    {
                        strContent3 = strContent3.Remove(0, intIx + 1);
                    }
                    else
                    {
                        break;
                    }

                }

                if (strContent3.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    /*Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content );*/
                    // Echo the data back to the client.
                    Send(handler, strContent3);
                }
                else
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
            else if (intPort == intPort4)
            {
                strContent4 += Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead);

                while (true)
                {

                    intIx = startParsing(strContent4, intPort);

                    if (intIx > 0)
                    {
                        strContent4 = strContent4.Remove(0, intIx + 1);
                    }
                    else
                    {
                        break;
                    }

                }

                if (strContent4.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    /*Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content );*/
                    // Echo the data back to the client.
                    Send(handler, strContent4);
                }
                else
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
            else if (intPort == intPort5)
            {
                strContent5 += Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead);

                while (true)
                {

                    intIx = startParsing(strContent5, intPort);

                    if (intIx > 0)
                    {
                        strContent5 = strContent5.Remove(0, intIx + 1);
                    }
                    else
                    {
                        break;
                    }

                }

                if (strContent5.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    /*Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content );*/
                    // Echo the data back to the client.
                    Send(handler, strContent5);
                }
                else
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
            // Check for end-of-file tag. If it is not there, read 
            // more data.





        }
        else
        {
            objReparse.finalize_Net(intPort);
            
            
        }
    }

    private static int startParsing(string strContent,int intPort)
    {
        int intIx;

        
        intIx = strContent.IndexOf("\n");
        
        if (intIx > 0)
        {
            
            objReparse.reparse_NET(strContent.Substring(0, intIx), intPort);
            if (intPort == intPort1)
            {
                lngLineCount1++;
            }
            else if (intPort == intPort2)
            {
                lngLineCount2++;
            }
            else if (intPort == intPort3)
            {
                lngLineCount3++;
            }
            else if (intPort == intPort4)
            {
                lngLineCount4++;
            }
            else if (intPort == intPort5)
            {
                lngLineCount5++;
            }
        }
        
        return intIx;
    }

    private static void Send(Socket handler, String data) {
        // Convert the string data to byte data using ASCII encoding.
        byte[] byteData = Encoding.ASCII.GetBytes(data);

        // Begin sending the data to the remote device.
        handler.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), handler);
    }

    private static void SendCallback(IAsyncResult ar) {
        try {
            // Retrieve the socket from the state object.
            Socket handler = (Socket) ar.AsyncState;

            // Complete sending the data to the remote device.
            int bytesSent = handler.EndSend(ar);
            //Console.WriteLine("Sent {0} bytes to client.", bytesSent);

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    }
}
