using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;

namespace PuppetMaster
{
    class PuppetMaster : PuppetServices
    {
        static void Main(string[] args)
        {

            TcpChannel channel = new TcpChannel(8086);
            ChannelServices.RegisterChannel(channel,false);
            
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(PuppetMaster), "ServerServices",  WellKnownObjectMode.Singleton);
            
            System.Console.WriteLine("<enter> para sair...");
            System.Console.ReadLine();
        }

        public int newWorker() {
            Worker worker = new Worker();

            Thread thread = new Thread(new ThreadStart(worker.check));

            thread.Start();
            // Spin for a while waiting for the started thread to become
            // alive:
            while (!thread.IsAlive) ;

            // Put the Main thread to sleep for 1 millisecond to allow oThread
            // to do some work:
            Thread.Sleep(1);

            // Request that oThread be stopped
            thread.Abort();

            // Wait until oThread finishes. Join also has overloads
            // that take a millisecond interval or a TimeSpan object.
            thread.Join();

            Console.WriteLine();
            Console.WriteLine("Worker has finished");

            return 0;
        }
    }
}
