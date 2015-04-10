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
        private List<Worker> workerslist;


        public PuppetServices()
        {
            workerslist = new List<Worker>();
        }
        public int createWorker(int id, String serviceUrl, String entryUrl)
        {
            Worker worker = new Worker(id, serviceUrl, entryUrl);
            Thread thread = new Thread(new ThreadStart(worker.check));

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

    }
}
