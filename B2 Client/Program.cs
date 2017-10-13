using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace B2_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); 
           
        
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0); 
            EndPoint Remote = (EndPoint)sender;

            byte[] data = new byte[4];
            client.ReceiveFrom(data, ref Remote);
            int serverChoosen = BitConverter.ToInt32(data, 0);

            Random rand = new Random();
            int clientChoossen = rand.Next(0, 2);

            if (clientChoosen == serverChoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Hoa");
                client.SendTo(send, Remote);
            }

            if (clientChoosen < serverChoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thang");
                client.SendTo(send, Remote);
            }
            if (clientChoosen > serverChoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thua");
                client.SendTo(send, Remote);
            }
        }
    }
}
