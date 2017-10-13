using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Bai_2____B2___server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); 
            server.Bind(ipep);
            Console.WriteLine("Waiting for a client..."); 
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0); 
            EndPoint Remote = (EndPoint)(sender);

            byte[] data = new byte[4];
            server.ReceiveFrom(data, ref Remote);
            int clientChoosen = BitConverter.ToInt32(data, 0);

            Random rand = new Random();
            int serverChoosen = rand.Next(0, 2);

            if (clientChoosen == serverChoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Hoa");
                server.SendTo(send, Remote);
            }

            if (clientChoosen < serverChoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thang");
                server.SendTo(send, Remote);
            }
            if (clientChoosen > serverChoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thua");
                server.SendTo(send, Remote);
            }
        }
    }
}
