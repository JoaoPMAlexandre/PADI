using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppetMaster
{
    class Worker
    {
        private JobTracker jobTracker;

        public Worker() {
            jobTracker = new JobTracker();
        }

        public void check() {
            while (true)
            {
                Console.WriteLine("I am alive!");
            }
        }

        private class JobTracker
        {

        }
    }
}
