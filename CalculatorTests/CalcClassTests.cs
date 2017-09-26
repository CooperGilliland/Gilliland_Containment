using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestClass()]
    public class CalcClassTests
    {
        [TestMethod()]
        public void AddIntegersTestPass()
        {
            //arrange
            CalcClass calc = new CalcClass();
            int intOne = 4;
            int intTwo = 5;
            int actualResult = 0;
            int expectedResult = 9;
            //act
            actualResult = calc.AddIntegers(intOne, intTwo);
            //assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        [TestMethod()]
        public void AddIntegersTestFail()
        {
            //arrange
            CalcClass calc = new CalcClass();
            int intOne = 2;
            int intTwo = 3;
            int actualResult = 0;
            int expectedResult = 10;
            //act
            actualResult = calc.AddIntegers(intOne, intTwo);
            //assert
            Assert.AreNotEqual(actualResult, expectedResult);
        }
    }
}