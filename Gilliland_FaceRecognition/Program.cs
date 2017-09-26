using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionManager;
using ComputerVisionAPI;

namespace Gilliland_FaceRecognition
{
    class Program
    {
        const string subKey = "058d169299344d6397912baa7e70cb21";
        const string basicURl = "https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze";
        const string queryParameters = "visualFeatures=Categories,Description,Color&language=en";
        static void Main(string[] args)
        {
            try
            {
                string imgLocation = "H:\test.jpg";
                //New container to format constant strings above into a usable whole 
                ConnectContainer urlTap = new ConnectContainer(subKey, basicURl, queryParameters);
                //New library object to interface with the Computer Vision API
                ImageContent dataTap = new ImageContent();
                //Get the result from the API as a JSON
                string finalContent = dataTap.RequestImageAnalysis(urlTap, imgLocation);
                Console.WriteLine(finalContent);
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
