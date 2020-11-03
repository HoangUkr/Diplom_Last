using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;

namespace Temporary_Server
{
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel(9090);

            ChannelServices.RegisterChannel(channel);
            IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
            string IP_temp = IP.AddressList[0].ToString();

            Console.WriteLine("Server started! (Server IP: " + IP_temp + ")");
            Console.WriteLine("History: ");
            RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("Temporary_Server.Server"), "Server", WellKnownObjectMode.Singleton); // Cho Server chat thuong           
            Console.ReadLine();
        }
    }
}
