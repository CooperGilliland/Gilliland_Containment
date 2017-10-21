using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalysisAPI;

namespace Gilliland_Sentiment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This Application takes raw text input and determines\n" +
                                  "the language, key phrases (if language is supported)\n"
                                  +"and sentiment. Sentiment is scored between 0 and 1\n"
                                  + "with 0 being negative and 1 being positive\n");
                Analyze textAnalyze = new Analyze();
                string input = "";
                bool cont = false;   
                //loop to collect multiple lines of text such as when text is copy pasted 
                while (!cont)
                {
                    Console.Write("-> ");                   
                    string holder = Console.ReadLine();    //collect user input              
                    if (holder == "y")
                    {
                        cont = true;
                    }
                    else
                    {
                        Console.WriteLine("Finished typing? Enter [y]es to continue to the analysis, or enter your next line of text.");
                        //aggragate input 
                        input += holder;
                    }

                }    
                //hand the user input to the analyzer 
                textAnalyze.Gambit(input);
                Console.WriteLine("\nPress Enter to Quit");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
