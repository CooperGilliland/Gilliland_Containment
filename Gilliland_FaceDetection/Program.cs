using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConnectionManager;
using FaceAPI;

namespace Gilliland_FaceDetection
{
    class Program
    {
        //These constants are for the various APIs. They supply the API key, the url to reach the API, and the parameters the API should return post analysis 
        //TODO: Determine if these should be located in the corresponding libraries instead. 
        const string subKey = "352060e3131e40668d7f859ee7675278";
        const string basicURl = "https://westus.api.cognitive.microsoft.com/face/v1.0/detect";
        const string queryParameters = "returnFaceId=true&returnFaceLandmarks=false";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This Application takes the filepath to an Image\n" +
                                  "and determines the number of faces, and their\n" +
                                  "locations in the image.\n");
                //New container to format constant strings above into a usable whole 
                ConnectContainer urlTap = new ConnectContainer(subKey, basicURl, queryParameters);
                //Create a new image analyzer 
                AnalyzeImage newAnalysis = new AnalyzeImage();
                Console.Write("Please enter the filepath of the Image being analyzed: ");
                string imgLocal = Console.ReadLine();
                //Call the analysis function, feeding it the Container and image location 
                //This action will return a JSON, which will be assigned to the Final Content variable
                string finalContent = newAnalysis.RequestImageAnalysis(urlTap, imgLocal);
                //This call will output the data required by the assignment 
                Console.WriteLine(finalContent);
                //GetFaceCoordinatesFromJson.JsonToText(finalContent);
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
