using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_8_17_Server_Excercise_4
{
    public class EchoService
    {
        public string LastMsg { get; set; }

        public string Echo(string input)
        {
            LastMsg = input;
            return input;
        }

        public string EchoLast()
        {
            return LastMsg;
        }

        public string EchoUpper(string input)
        {
            string upperInput = input.ToUpper();
            LastMsg = upperInput;
            return upperInput;
        }
    }
}
