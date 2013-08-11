using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace ipmatch
{
    class Program
    {
        

        public static bool hasip(String s)
        {
	        Regex ip = new Regex("^([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\.([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\.[01]?\\d\\d?|2[0-4]\\d|25[0-5]\\.[01]?\\d\\d?|2[0-4]\\d|25[0-5]$");
	        return ip.IsMatch(s);
        }

        public static void FindIP()
        {
	        string line;
            using(StreamReader sr = new StreamReader("IP.txt"))
	        {
		        while((line = sr.ReadLine()) != null)
		        {
			        String[] words = line.Split(' ');
			        foreach(String s in words)
			        {
				        if(hasip(s))
				        {
					        Console.WriteLine(s);
					        using(StreamWriter sw = File.AppendText("iplines.txt"))
					        {						        
                                sw.WriteLine(line);
					        }

					        break;
				        }
				
			        }
		        }
	        }
        }
        
        static void Main(string[] args)
        {
            FindIP();
            Console.ReadLine();
        }
    }
}
