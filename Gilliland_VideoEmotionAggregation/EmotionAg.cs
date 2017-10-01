using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionManager;
using EmotionAPI;
using Newtonsoft.Json;
namespace Gilliland_VideoEmotionAggregation
{
    class EmotionAg
    {
        const string subKey = "fe080a4f9d5d40f58fe266a4a00b1861";
        const string basicURl = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize";
        const string queryParameters = "";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This Application takes the filepath to an Image\n" +
                                  "and determines the emotional scores for each\n" +
                                  "face detected in the image.\n");
                //New container to format constant strings above into a usable whole 
                ConnectContainer urlTap = new ConnectContainer(subKey, basicURl, queryParameters);
                //Create a new image analyzer 
                EmotionDetection newAnalysis = new EmotionDetection();
                Console.Write("Please enter the filepath of the Image being analyzed: ");
                string imgLocal = Console.ReadLine();
                //Call the analysis function, feeding it the Container and image location 
                //This action will return a JSON, which will be assigned to the Final Content variable
                string finalContent = newAnalysis.RequestAnalysis(urlTap, imgLocal);
                //deserialize the JSON results
                dynamic des = JsonConvert.DeserializeObject(finalContent);
                int faceCount = 0; //add a variable to keep track of the total faces 
                foreach (var thing in des)
                {
                    faceCount++;
                    //output the data required by the assignment 
                    Console.WriteLine("\nFace {0}: \n {1}", faceCount, thing.scores);
                }
                
                
                Console.WriteLine("Press Enter to Quit");
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
