using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Telemetry_Server.NET
{
    /// <summary>
    /// Class handling data transfer using POST/GET requests
    /// </summary>
    class WebSender
    {
        private Form1 form1Controller; //UI handle
        private Thread webSenderThread;

        private static bool run = false;

        /// <summary>
        /// Creates new WebSender instance
        /// </summary>
        /// <param name="f1">Reference to UI</param>
        public WebSender(Form1 f1)
        {
            form1Controller = f1;
        }

        /// <summary>
        /// Starts thread for web transmission
        /// </summary>
        public void StartTransmission()
        {
            run = true;
            webSenderThread = new Thread(new ThreadStart(ContactServer));
            webSenderThread.Start();
        }

        /// <summary>
        /// Sets stop flag to safely end thread
        /// </summary>
        /// <remarks>
        /// May kill thread using Abort() method if it won't end during 4 seconds period
        /// </remarks>
        public void StopTransmission()
        {
            run = false;

            Thread.Sleep(2000);
            if (webSenderThread.IsAlive)
                webSenderThread.Join();
            else
                return;

            Thread.Sleep(2000);
            if (webSenderThread.IsAlive)
                webSenderThread.Abort();
        }

        /// <summary>
        /// Push telemetry data using GET request
        /// </summary>
        private void UseGET()
        {
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(Config.GetURLData());
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Clean up the streams and the response.
            reader.Close();
            response.Close();

            form1Controller.Invoke(form1Controller.changeWebStatus, responseFromServer);
        }

        /// <summary>
        /// Push telemetry data using POST request
        /// </summary>
        private void UsePOST()
        {
            //The method we will use to send the data, this can be POST or GET.
            string requestmethod = "POST";

            //Here we will enter the data to send, just like if we where to go to a webpage and enter variables,
            // we would type: "www.somesite.com?var1=Hello&var2=Server!"!
            string webData = Config.GetURLData(DataReader.dataPacket.ToString());

            //The Byte Array that will be used for writing the data to the stream.
            byte[] byteArray = Encoding.UTF8.GetBytes(webData);

            //The URL of the webpage to send the data to.
            string url = Config.websiteAddress;

            //The type of content being send, this is almost always "application/x-www-form-urlencoded".
            string contenttype = "application/x-www-form-urlencoded";

            //What the server sends back:
            string responseFromServer = null;

            //Here we will create the WebRequest object, and enter the URL as soon as it is created.
            WebRequest request = WebRequest.Create(url);

            //We also need a Stream:
            Stream dataStream;

            //...And a webResponce,
            WebResponse response;

            //don't forget the streamreader either!
            StreamReader reader;

            //We will need to set the method used to send the data.
            request.Method = requestmethod;

            //Then the contenttype:
            request.ContentType = contenttype;

            //content length
            request.ContentLength = byteArray.Length;

            //ok, now get the request from the webRequest object, and put it into our Stream:
            dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            dataStream.Close();

            //Get the responce
            response = request.GetResponse();

            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();

            //Open the responce stream:
            reader = new StreamReader(dataStream);

            //read the content into the responcefromserver string
            responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            Console.WriteLine(responseFromServer);

            form1Controller.Invoke(form1Controller.changeWebStatus, responseFromServer);
        }

        /// <summary>
        /// Function used by thread, calling apropriate method for contacting web server
        /// </summary>
        private void ContactServer()
        {
            while (run)
            {
                try
                {
                    if (Config.usePost)
                        UsePOST();
                    else
                        UseGET();
                }
                catch (WebException we)
                {
                    MessageBox.Show("There's problem with contacting server. Connection will be terminated. Error: \n" + we.ToString());
                    return;
                }

                Thread.Sleep(Config.sendInterval);
            }
        }
    }
}
