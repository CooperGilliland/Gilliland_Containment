using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerVisionAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionManager;

namespace ComputerVisionAPI.Tests
{
    [TestClass()]
    public class ImageContentTests
    {
        /// <summary>
        /// This test will determine if the connection is occuring 
        /// </summary>
        [TestMethod()]
        public void RequestImageAnalysisTestPass()
        {
            try
            {
                //arrange
                const string subKey = "058d169299344d6397912baa7e70cb21";
                const string basicURl = "https://westus.api.cognitive.microsoft.com/vision/v1.0/ocr";
                const string queryParameters = "";
                ConnectContainer urlTap = new ConnectContainer(subKey, basicURl, queryParameters);
                string imgLocal = "textTest.png";
                //Create a new image analyzer 
                ImageContent newAnalysis = new ImageContent();
                //act
                //Call the analysis function, feeding it the Container and image location 
                //This action will return a JSON, which will be assigned to the Final Content variable
                dynamic finalContent = newAnalysis.RequestImageAnalysis(urlTap, imgLocal);
            }
            //assert
            catch (Exception e)
            {
                Assert.Fail();
            }


        }
        /// <summary>
        /// This test passes if an error is thrown
        /// </summary>
        [TestMethod()]
        public void RequestImageAnalysisTestFail()
        {
            try
            {
                //arrange
                const string subKey = "058d169299344d6397912baa7e70cb21";
                const string basicURl = "https://westus.api.cognitive.microsoft.com/vision/v1.0/ocr";
                const string queryParameters = "";
                ConnectContainer urlTap = new ConnectContainer(subKey, basicURl, queryParameters);
                string imgLocal = "textTesst.png";
                //Create a new image analyzer 
                ImageContent newAnalysis = new ImageContent();
                //act
                //Call the analysis function, feeding it the Container and image location 
                //This action will return a JSON, which will be assigned to the Final Content variable
                dynamic finalContent = newAnalysis.RequestImageAnalysis(urlTap, imgLocal);
                //assert
                Assert.Fail();
            }
            catch (Exception e)
            {

            }

        }

    }
}