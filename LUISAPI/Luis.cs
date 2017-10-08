using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Cognitive.LUIS;

namespace LUISAPI
{
    public class Luis
    {
        public event EventHandler<LuisUtteranceResultEventArgs> OnLuisUtteranceResultUpdated; 
        private LuisClient _luisClient;
        public bool isRunning = true;
        public Luis(LuisClient luisClient)
        {
            _luisClient = luisClient;
        }

        private void RaiseOnLuisUtteranceResultUpdated(LuisUtteranceResultEventArgs args)
        {
            OnLuisUtteranceResultUpdated?.Invoke(this, args);
        }
        public async Task RequestAsync(string input)
        {
            try
            {
                LuisResult result = await _luisClient.Predict(input);
                ProcessResult(result);
            }
            catch (Exception e)
            {
                RaiseOnLuisUtteranceResultUpdated(new LuisUtteranceResultEventArgs{Status = "Failed", Message = e.Message});
            }
        }
        private void ProcessResult(LuisResult result)
        {
            LuisUtteranceResultEventArgs args = new LuisUtteranceResultEventArgs();
            args.Status = "Succeeded";
            args.Message =
                $"Top intent is {result.TopScoringIntent.Name} " +
                $"with score {result.TopScoringIntent.Score}. Found " +
                $"{result.Entities.Count} entities.";
            RaiseOnLuisUtteranceResultUpdated(args);
            Console.WriteLine(args.Message);
            isRunning = false;
        }
    }
}
