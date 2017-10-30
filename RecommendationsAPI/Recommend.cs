using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recommendations;

namespace RecommendationsAPI
{
    public class Recommend
    {
        public static void ItemToItemRecommendation(RecommendationsApiWrapper recommender, string modelId, long buildId)
        {
            Console.WriteLine();
            Console.WriteLine("Getting Item to Item 5C5-00025");
            const string itemIds = "5C5-00025";
            var itemSets = recommender.GetRecommendations(modelId, buildId, itemIds, 6);
            if (itemSets.RecommendedItemSetInfo != null)
            {
                foreach (RecommendedItemSetInfo recoSet in itemSets.RecommendedItemSetInfo)
                {
                    foreach (var item in recoSet.Items)
                    {
                        Console.WriteLine("Item id: {0} \n Item name: {1} \t (Rating  {2})", item.Id, item.Name, recoSet.Rating);
                    }
                }
            }
            else
            {
                Console.WriteLine("No recommendations found.");
            }
        }
    }
}
