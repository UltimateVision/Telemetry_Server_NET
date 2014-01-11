using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Telemetry_Server.NET
{
    class SocketServer
    {
        private static object _lock = new object(); //lock on run variable
        private static object _lock2 = new object(); //lock on Lists
        private static object _formControlLock = new object();

        private Form1 form1Controller; //reference to UI

        private TcpListener listener;
        private Thread listenThread;
        private Thread slotWatcher;
        private bool run = false;

        Thread[] clients;
        List<int> slotsAvailable;
        List<int> slotsOcuppied;

        public SocketServer(Form1 controller)
        {
            form1Controller = controller;
            clients = new Thread[4];
            slotsAvailable = new List<int>();
            for(int i = 0; i < 4; i++)
                slotsAvailable.Add(i);
            slotsOcuppied = new List<int>();
        }

        public static string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            string ipAddr = "?";
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    ipAddr = ip.ToString();
            }
            return ipAddr;
        }

        public void Start()
        {
            listener = new TcpListener(IPAddress.Any, 19000);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            slotWatcher = new Thread(new ThreadStart(SlotWatcher));

            run = true;
            listener.Start();
            listenThread.Start();
            slotWatcher.Start();
        }

        public void Stop()
        {
            lock (_lock)
                run = false;

            listener.Stop();
        }

        //Accepts clients connections
        private void ListenForClients()
        {
            while (run)
            {
                if (slotsAvailable.Count > 0)
                {
                    int slot = slotsAvailable[0];
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        clients[slot] = new Thread(new ParameterizedThreadStart(HandleClient));
                        clients[slot].Start(client);

                        lock(_formControlLock)
                            form1Controller.Invoke(form1Controller.incrementClient); //Update UI's client counter

                        lock (_lock2)
                        {
                            slotsOcuppied.Add(slot);
                            slotsAvailable.Remove(slot);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    while (true)
                    {
                        int c = 0;
                        lock (_lock2)
                            c = slotsAvailable.Count;
                        if (c == 0)
                            Thread.Sleep(500);
                        else
                            break;
                    }
                }
            }

            Console.WriteLine("Client listener ended!");
        }

        //Handles client behaviour
        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream clientStream = client.GetStream();

            while (run)
            {
                try
                {
                    byte[] byteData = new byte[4096];
                    byteData = Encoding.ASCII.GetBytes(DataReader.dataPacket.ToString());
                    clientStream.Write(byteData, 0, byteData.Length);
                    Thread.Sleep(Config.sendInterval);
                }
                catch (IOException) //Client has disconnected (probably)
                {
                    lock (_formControlLock)
                        form1Controller.Invoke(form1Controller.decrementClient); //Update UI's client counter
                    client.Close();
                    Console.WriteLine("Client terminated connection!");
                    return;
                }
            }

            lock (_formControlLock)
                form1Controller.Invoke(form1Controller.decrementClient); //Update UI's client counter

            client.Close();
            Console.WriteLine("Server terminated connection!");
        }

        //Slot manager thread function
        private void SlotWatcher()
        {
            while (run)
            {
                lock (_lock2)
                {
                    for (int i = 0; i < slotsOcuppied.Count; i++)
                    {
                        if (!clients[i].IsAlive)
                        {
                            slotsOcuppied.Remove(i);
                            slotsAvailable.Add(i);
                        }
                    }
                }

                Thread.Sleep(500);
            }

            Console.WriteLine("Slot watcher ended!");
        }
    }
}
