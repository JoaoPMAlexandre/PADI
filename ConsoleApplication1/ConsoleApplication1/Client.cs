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
    
        public String getPuppetMasterUrl() {
            return puppetMasterUrl;
        }
        public void setPuppetMasterUrl(String url) {
            puppetMasterUrl = url;
        }

        public void toStringInfo() {
            String s = "number of workers: " + services.getWorkerlistSize() + "; URL: " + getPuppetMasterUrl();
            Console.WriteLine(s); 

        }
           
        public Client(String url) {
            this.puppetMasterUrl = url;    
        }
        
        public int Connect() {
            try
            {
                
                TcpChannel channel = new TcpChannel();
                ChannelServices.RegisterChannel(channel, false);
                WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(typeof(PuppetServices), puppetMasterUrl);
                RemotingConfiguration.RegisterWellKnownClientType(remoteType);
                
                string objectUri;
                System.Runtime.Remoting.Messaging.IMessageSink messageSink = channel.CreateMessageSink(puppetMasterUrl, null, out objectUri);

                services = new PuppetServices();
                return 0;
            }
            catch (RemotingException e)
            {
                Console.WriteLine(e.StackTrace);
                return -1;
            }
        }

        public void createWorker(int id, String serviceUrl, String entryUrl)
        {
            services.createWorker(id, serviceUrl, entryUrl);
        }
    }
}
