using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeExplorationAPI;
namespace Gilliland_Win10FaQ
{
    class Program
    {

        static void Main(string[] args)
        {
                 
            try
            {               
                bool isRunning = true; //variable to control exit protocol 
                //information for users 
                Console.WriteLine("This Application answers frequently asked questions\n" +
                                  "About the Windows 10 operating system\n");
                while (isRunning)
                {
                    //Give users information 
                    Console.Write("Either submit a question, or type \"exit\" to quit.\n-> ");
                    string query = Console.ReadLine(); //collect user input 
                    if (query == "exit" || query == "Exit") //check if user wants to quit
                    {
                        isRunning = false; 
                    }
                    else
                    {
                        //Create a new API wrapper 
                        FaQConnector newFaQ = new FaQConnector();
                        newFaQ.QueryResult(query); //hand off the user query for broadcast
                        newFaQ.formatOutput(); //Output the results to the console 
                    }
                }
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}