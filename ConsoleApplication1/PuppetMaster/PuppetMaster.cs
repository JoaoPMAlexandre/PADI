using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;

namespace PuppetMaster
{
    class PuppetMaster 
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(8086);
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(PuppetServices), "ServerServices", WellKnownObjectMode.Singleton);

            System.Console.WriteLine("<enter> para sair...");
            System.Console.ReadLine();
        }
    }
}
