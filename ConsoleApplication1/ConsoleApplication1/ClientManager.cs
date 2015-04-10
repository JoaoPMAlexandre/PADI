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
                    int id;
                    
                    try
                    {
                        id = Convert.ToInt32(cmd[1]);
                        Client client = new Client(cmd[2]);
                        if (cmd.Length == 4)
                        {
                          client.createWorker(id, cmd[3], cmd[4]);
                        }
                        if (cmd.Length == 3)
                        {
                            client.createWorker(id, cmd[3], null);
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    catch (IndexOutOfRangeException e)
                    {                    
                        Console.WriteLine(e.StackTrace);
                    }
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
