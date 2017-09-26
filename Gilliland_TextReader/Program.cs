using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionManager;
using ComputerVisionAPI;
namespace Gilliland_FaceCompare
{
    class Program
    {

        const string subKey = "058d169299344d6397912baa7e70cb21";
        const string basicURl = "https://westus.api.cognitive.microsoft.com/vision/v1.0/ocr";
        const string queryParameters = "";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This Application takes the filepath to an Image\n" +
                                  "containing text elements, and returns a machine-\n" +
                                  "useable character stream.\n");
                //New container to format constant strings above into a usable whole 
                ConnectContainer urlTap = new ConnectContainer(subKey, basicURl, queryParameters);
                //Create a new image analyzer 
                ImageContent newAnalysis = new ImageContent();
                Console.Write("Please enter the filepath of the Image being analyzed: ");
                string imgLocal = Console.ReadLine();
                //Call the analysis function, feeding it the Container and image location 
                //This action will return a JSON, which will be assigned to the Final Content variable
                dynamic finalContent = newAnalysis.RequestImageAnalysis(urlTap, imgLocal);
                //This call will output the data required by the assignment 
                JsonFormat.JsonToText(finalContent);
                Console.WriteLine("\nPress Enter to Quit");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                //Output any error messages to console 
                Console.WriteLine("Error: {0}", e.Message);
                Console.ReadLine();
            }
        }
    }
}
