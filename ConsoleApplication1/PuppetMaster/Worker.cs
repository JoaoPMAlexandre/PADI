using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PuppetMaster
{
    class Worker
    {
        private int id
        {
            get { return id; }
            set { id = value; }
        }

        private JobTracker jobTracker;

        public Worker(int id, String serviceUrl, String entryUrl)
        {
            this.id = id;
            jobTracker = new JobTracker(serviceUrl, entryUrl);
        }

        public void check() {
            while (true)
            {
                Console.WriteLine("I am alive!");
            }
        }

        public void freezeWorker()
        {
            Console.WriteLine("This Thread is freezed");
        }

        private class JobTracker
        {
            private String serviceUrl
            {
                get { return serviceUrl; }
                set { serviceUrl = value; }
            }
            private String entryUrl
            {
                get { return entryUrl; }
                set { entryUrl = value; }
            }

            public JobTracker(String serviceUrl, String entryUrl)
            {
                this.serviceUrl = serviceUrl;
                this.entryUrl = entryUrl;
            }

        }
    }
}
