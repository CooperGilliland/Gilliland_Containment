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
            string query = "hi"; 
            FaQConnector newFaQ = new FaQConnector();
            FaQHelper results = newFaQ.QueryResult(query);            
            Console.ReadLine();
        }
    }
}