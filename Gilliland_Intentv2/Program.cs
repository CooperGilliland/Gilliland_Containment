using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LUISAPI;

namespace Gilliland_Intentv2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Create Variables 
                string contextId = "";
                string question = "";
                AnalyzeIntent Analyzer = new AnalyzeIntent();
                dynamic results = "";
                Console.WriteLine("This Application takes a querry related to making and removing notes\n" +
                                  "and determines the probable intent of the user, based on what they wrote.\nPlease enter data now -> ");
                //Call the luis ai over async 
                question = Console.ReadLine();
                Task.Run(async () =>
                {
                    //collect results of call to ai 
                    results = await Analyzer.MakeRequest(question, contextId);
                }).Wait();
                //output the results of the call 
                Console.WriteLine(results);
                Console.WriteLine("Press Enter to Quit");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
