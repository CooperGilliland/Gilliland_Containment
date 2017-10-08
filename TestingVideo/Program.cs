using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmotionAPI;

namespace TestingVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoEmotionRecognition x = new VideoEmotionRecognition();
            string result = x.PerformRequestAndWaitForResponse("D:\\doit.wmv");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
