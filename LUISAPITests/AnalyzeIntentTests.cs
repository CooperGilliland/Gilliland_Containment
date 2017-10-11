using Microsoft.VisualStudio.TestTools.UnitTesting;
using LUISAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUISAPI.Tests
{
    [TestClass()]
    public class AnalyzeIntentTests
    {
        [TestMethod()]
        public void MakeRequestTestPass()
        {
            //arrange
            try
            {
                string contextId = "";
                string question = "add item to list";
                AnalyzeIntent Analyzer = new AnalyzeIntent();
                dynamic results = "";
                //act
                Task.Run(async () =>
                {
                    //collect results of call to ai 
                    results = await Analyzer.MakeRequest(question, contextId);
                }).Wait();
            }
            //assert
            catch (Exception e)
            {
                Assert.Fail();
            }

        }
        [TestMethod()]
        public void MakeRequestTestFail()
        {
            //arrange
            try
            {
                string contextId = "";
                string question = "";
                AnalyzeIntent Analyzer = new AnalyzeIntent();
                dynamic results = "";
                //act
                Task.Run(async () =>
                {
                    //collect results of call to ai 
                    results = await Analyzer.MakeRequest(question, contextId);
                }).Wait();
                //assert
                Assert.Fail();
            }

            catch (Exception e)
            {

            }
        }
    }
}