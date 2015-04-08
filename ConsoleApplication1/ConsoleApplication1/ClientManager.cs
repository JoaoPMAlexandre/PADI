using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADIProject
{
    public class ClientManager
    {
        Dictionary<int, String> Map;

        public static void Main(string[] args)
        {
            String instruction = "default";
            char[] separators = { ' ' };

            while (!instruction.Contains("quit"))
            {
                instruction = Console.ReadLine();

                String[] cmd = instruction.Split(separators);

                if (cmd[0].ToLower().Equals("worker"))
                {
                    Client client = new Client(cmd[1]);
                    client.createWorker();
                }
            }


        }

        public ClientManager()
        {
            Map = new Dictionary<int, String>();
        }

        public Dictionary<int, String> GetMap()
        {
            return Map;
        }

        public void readFileAndParseIt(String PathFile)
        {
            string[] lines = System.IO.File.ReadAllLines(@PathFile);

            for (int i = 0; i < lines.Length; i++)
            {
                GetMap().Add(i, lines[i]);
                Console.WriteLine(GetMap().ElementAt(i));
            }
        }
    }
}
