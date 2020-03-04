using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Server
{

    class Program
    {
        private static ManualResetEvent allDone = new ManualResetEvent(false);
        public static List<Celsius> listOfCelsius;
        static void Main(string[] args)
        {
            IPAddress ipAddress = IPAddress.Parse("192.168.150.89");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 12345);

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listOfCelsius = new List<Celsius>();
            listener.Bind(localEndPoint);
            listener.Listen(100);
            Cmaker();
            Console.WriteLine(listOfCelsius.Count);
            Save();
            /*
            while (true)
            {
                allDone.Reset();

                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                allDone.WaitOne();
            }
            */
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket client = listener.EndAccept(ar);

            //WHILE loop

            byte[] buff = new byte[1024];
            int bytesReads = client.Receive(buff);

            if (bytesReads < buff.Length)
            {
                Random rnd = new Random();
                int num = rnd.Next(-10, 40);
                int id = rnd.Next(-200, 200);
                if (Encoding.ASCII.GetString(buff, 0, bytesReads).ToLower() == "celsius")
                {
                    Console.WriteLine($"Celsius: {num} \nID:{id}"); //Send back to sender.
                    
                    // SaveCelsius(num,id);
                }
                Console.WriteLine("PITE: {0} {1}", bytesReads, Encoding.ASCII.GetString(buff, 0, bytesReads));
                
            }
            else
            {
                Console.WriteLine("KEX");

            }
            client.Close();

        }
        public static void Cmaker()
        {
            Random rnd = new Random();
            int num = rnd.Next(-10, 40);
            int id = rnd.Next(-200, 200);
            DateTime now = DateTime.Now;
            int sec = now.Hour * 3600 + now.Minute * 60 + now.Second;
            num = rnd.Next(-10, 40);
            id = rnd.Next(-200, 200);
            Celsius celsius = new Celsius(id, num, sec);
            listOfCelsius.Add(celsius);
            sec = now.Hour * 3600 + now.Minute * 60 + now.Second;
            num = rnd.Next(-10, 40);
            id = rnd.Next(-200, 200);
            celsius = new Celsius(id, num, sec);
            listOfCelsius.Add(celsius);
            sec = now.Hour * 3600 + now.Minute * 60 + now.Second;
            num = rnd.Next(-10, 40);
            id = rnd.Next(-200, 200);
            celsius = new Celsius(id, num, sec);
            listOfCelsius.Add(celsius);
            sec = now.Hour * 3600 + now.Minute * 60 + now.Second;
            num = rnd.Next(-10, 40);
            id = rnd.Next(-200, 200);
            celsius = new Celsius(id, num, sec);
            listOfCelsius.Add(celsius);
            sec = now.Hour * 3600 + now.Minute * 60 + now.Second;
            num = rnd.Next(-10, 40);
            id = rnd.Next(-200, 200);
            celsius = new Celsius(id, num, sec);
            listOfCelsius.Add(celsius);

        }
        public static void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Celsius>));

            using (Stream tw = new FileStream("celsius.xml", FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(tw, listOfCelsius);
            }
        }
        
        public static void Deserializer (string fileName = "celsius.xml")
        {
            XElement element = XElement.Load(fileName);
            var partNodes = element.Elements("Temperatures");
            
            foreach (var node in partNodes)
            {
                Celsius c = new Celsius();

            }

            /*
                markOfC = node.Element("Celsius").Value;
                game._releaseYear = Convert.ToInt32(node.Element("_releaseYear").Value);
                game._price = Convert.ToInt32(node.Element("_price").Value);
                game._finished = Convert.ToBoolean(node.Element("_finished").Value);
                game._owned = Convert.ToBoolean(node.Element("_owned").Value);

                _listOfGames.Add(game);

            return _listOfGames;
            */
        }   
        /*
        public void SaveDickSize(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Game>));

            using (Stream tw = new FileStream("fbay.xml", FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(tw, _listOfGames);
            }
        }
        public void SaveBodySize(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Game>));

            using (Stream tw = new FileStream("fbay.xml", FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(tw, _listOfGames);
            }
        }
        */
    }
}
