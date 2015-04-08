using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADIMapNoReduce
{
    public class UserInterface
    {
        Dictionary<int, String> Map;

        public static void Main(string[] args)
        {
            UserInterface userinterface = new UserInterface();
            string inputFile = Console.ReadLine();
             userinterface.readFileAndParseIt(inputFile);
            while (true)
            {
            }
        }

        public UserInterface()
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

            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine("\t" + lines[i]);
            }
        }
    }
}
