using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmotionAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionManager;
using Newtonsoft.Json;

namespace EmotionAPI.Tests
{
    [TestClass()]
    public class EmotionDetectionTests
    {
        [TestMethod()]
        public void RequestAnalysisTestPass()

        {
            //arrange
            const string subKey = "fe080a4f9d5d40f58fe266a4a00b1861";
            const string basicURl = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize";
            const string queryParameters = "";
            int expectedResult = 3;
            int actualResult = 0;
            //act
            //New container to format constant strings above into a usable whole 
            ConnectContainer urlTap = new ConnectContainer(subKey, basicURl, queryParameters);
            //Create a new image analyzer 
            EmotionDetection newAnalysis = new EmotionDetection();
            string imgLocal = "test.jpg";
            //Call the analysis function, feeding it the Container and image location 
            //This action will return a JSON, which will be assigned to the Final Content variable
            string jsonCollection = newAnalysis.RequestAnalysis(urlTap, imgLocal);
            //deserialize the JSON results
            dynamic dynamDeserializeObjectJson = JsonConvert.DeserializeObject(jsonCollection);
            //Iterate through result, adding up the number of faces detected
            foreach (var items in dynamDeserializeObjectJson)
            {
                actualResult++;
            }
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}