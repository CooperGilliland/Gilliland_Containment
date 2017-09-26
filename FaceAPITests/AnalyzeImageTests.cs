using ConnectionManager;
using FaceAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;


namespace FaceAPITests
{
    [TestClass()]
    public class AnalyzeImageTests
    {
        /// <summary>
        /// This test will determine if the correct number of faces are being detected 
        /// </summary>
        [TestMethod()]
        public void RequestImageAnalysisTestPass()
        {
            //arrange 
            //These constants are for the various APIs. They supply the API key, the url to reach the API, and the parameters the API should return post analysis 
            const string subKey = "352060e3131e40668d7f859ee7675278";
            const string basicURl = "https://westus.api.cognitive.microsoft.com/face/v1.0/detect";
            const string queryParameters = "returnFaceId=true&returnFaceLandmarks=false";
            int actualResult = 0;
            int expectedResult = 3;
            string imgLocation = "test.jpg"; //filepath to image being analyzed 
            //Create a new image analyzer 
            AnalyzeImage imageAnalyzer = new AnalyzeImage();
            //New container to format constant strings above into a usable whole 
            ConnectContainer urlContainer = new ConnectContainer(subKey, basicURl, queryParameters);
            //act
            //Assign results of analysis to variable 
            string jsonCollection = imageAnalyzer.RequestImageAnalysis(urlContainer, imgLocation);
            dynamic dynamDeserializeObjectJson = JsonConvert.DeserializeObject(jsonCollection);
            //Iterate through result, adding up the number of faces detected
            foreach (var face in dynamDeserializeObjectJson)
            {
                actualResult++; //add to the total number of faces 
            }
            //assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        /// <summary>
        /// This test asserts 0 faces, and passes when the result does not match this  
        /// Being that the test image contains three faces
        /// </summary>
        [TestMethod()]
        public void RequestImageAnalysisTestFail()
        {
            //arrange 
            //These constants are for the various APIs. They supply the API key, the url to reach the API, and the parameters the API should return post analysis 
            const string subKey = "352060e3131e40668d7f859ee7675278";
            const string basicURl = "https://westus.api.cognitive.microsoft.com/face/v1.0/detect";
            const string queryParameters = "returnFaceId=true&returnFaceLandmarks=false";
            int actualResult = 0;
            int expectedResult = 0;
            string imgLocation = "test.jpg"; //filepath to image being analyzed 
            //Create a new image analyzer 
            AnalyzeImage imageAnalyzer = new AnalyzeImage();
            //New container to format constant strings above into a usable whole 
            ConnectContainer urlContainer = new ConnectContainer(subKey, basicURl, queryParameters);
            //act
            //Assign results of analysis to variable 
            string jsonCollection = imageAnalyzer.RequestImageAnalysis(urlContainer, imgLocation);
            dynamic dynamDeserializeObjectJson = JsonConvert.DeserializeObject(jsonCollection);
            //Iterate through result, adding up the number of faces detected
            foreach (var face in dynamDeserializeObjectJson)
            {
                actualResult++; //add to the total number of faces 
            }
            //assert
            Assert.AreNotEqual(actualResult, expectedResult);
        }
    }
}