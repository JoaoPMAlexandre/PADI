using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PuppetMaster
{
    public class PuppetServices
    {
        private Dictionary<int, Worker> workerlist;


        public PuppetServices()
        {
            workerlist = new Dictionary<int,Worker>();
        }
        public int createWorker(int id, String serviceUrl, String entryUrl)
        {
            Worker worker = new Worker(id, serviceUrl, entryUrl);
            workerlist.Add(id, worker);
            Thread thread = new Thread(new ThreadStart(worker.check)); //Just a test, to see if it exists

            if (entryUrl != null)
            {
                //SupostoAvisarOListeningWorker
            }

            thread.Start();
            while (!thread.IsAlive) ;

            Console.WriteLine();
            Console.WriteLine("Worker has finished");

            return 0;
        }

        public void freeze(int id)
        {
            Worker worker = workerlist[id];
            Thread thread = new Thread(new ThreadStart(worker.freezeWorker));
            thread.Suspend();
        }

        public void unfreeze(int id)
        {
            Worker worker = workerlist[id];

        }

    }
}
