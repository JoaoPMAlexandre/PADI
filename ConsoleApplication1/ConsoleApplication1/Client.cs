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
    public class Client
    {
        private PuppetServices services;
        private String puppetMasterUrl;

        public Client(String url) {
            try
            {
                puppetMasterUrl = url;
                TcpChannel channel = new TcpChannel();
                ChannelServices.RegisterChannel(channel, false);
                WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(typeof(PuppetServices), puppetMasterUrl);
                RemotingConfiguration.RegisterWellKnownClientType(remoteType);
                
                string objectUri;
                System.Runtime.Remoting.Messaging.IMessageSink messageSink = channel.CreateMessageSink(puppetMasterUrl, null, out objectUri);

                services = new PuppetServices();   
            }
            catch (RemotingException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void createWorker()
        {
            services.newWorker();
        }
    }
}
