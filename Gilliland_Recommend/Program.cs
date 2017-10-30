using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recommendations;
using RecommendationsAPI;

namespace Gilliland_Recommend
{
    class Program
    {
        private static string AccountKey = "7ad247f9090a42798bc2d08eb033316f"; // <---  Set to your API key here.
        private const string BaseUri = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0";
        private static RecommendationsApiWrapper recommender = null;
        static void Main(string[] args)
        {
            string modelName = "MyNewModel";
            string modelId = "82cd6f82-1ec9-4483-a37e-40772affba13";
            long buildId = 1663961;
            try
            {
                recommender = new RecommendationsApiWrapper(AccountKey, BaseUri);
                Recommend.ItemToItemRecommendation(recommender, modelId, buildId);
                Console.WriteLine("Press any key to end");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encountered:");
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
