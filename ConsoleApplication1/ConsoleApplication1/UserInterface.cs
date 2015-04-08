using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADIProject
{
    public class UserInterface
    {
        Dictionary<int, String> Map;

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

            for (int i = 0; i < lines.Length; i++)
            {
                GetMap().Add(i, lines[i]);
                Console.WriteLine(GetMap().ElementAt(i));
            }
        }
    }
}
