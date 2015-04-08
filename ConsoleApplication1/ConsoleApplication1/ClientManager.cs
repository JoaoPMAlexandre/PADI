using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using PuppetMaster;

namespace PADIProject
{
    public class ClientManager
    {
        public static void Main(string[] args)
        {
            UserInterface userinterface = new UserInterface();
            //string inputFile = Console.ReadLine();
            userinterface.readFileAndParseIt("C:/Users/João Alexandre/Documents/Test.txt");
            try
            {
                TcpChannel channel = new TcpChannel();
                ChannelServices.RegisterChannel(channel, false);
                WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(typeof(PuppetServices), "tcp://localhost:8086/PuppetServices");
                RemotingConfiguration.RegisterWellKnownClientType(remoteType);
                string objectUri;
                System.Runtime.Remoting.Messaging.IMessageSink messageSink =
                    channel.CreateMessageSink(
                        "tcp://localhost:8086/PuppetServices", null,
                        out objectUri);
                Console.WriteLine("The URI of the message sink is {0}.",
                    objectUri);
                if (messageSink != null)
                {
                    Console.WriteLine("The type of the message sink is {0}.",
                        messageSink.GetType().ToString());
                }
                PuppetServices services = new PuppetServices();
                services.newWorker();
            }
            catch (RemotingException e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }


    }
}
