using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace TextAnalysisAPI
{
    public class Analyze
    {
        private const string apiKey = "ab37198f91c64e839bbd8bb21edf9bd6";
        private ITextAnalyticsAPI apiClient;
        private string language = "";
        /// <summary>
        /// initilize the API object being used by the class
        /// </summary>
        public Analyze()
        {         
            apiClient = new TextAnalyticsAPI
            {
                //give the api the needed region and keys 
                AzureRegion = AzureRegions.Westus,
                SubscriptionKey = apiKey
            };            
        }
        /// <summary>
        /// wrap access to other private functions 
        /// </summary>
        /// <param name="dataToAnalyze"></param>
        public void Gambit(string dataToAnalyze)
        {
            DetermineLanguage(dataToAnalyze);
            DetermineKeyPhrases(dataToAnalyze);
            DetermineSentiment(dataToAnalyze);
        }
        /// <summary>
        /// determine the language of the incoming text
        /// this determination will be used by later functions
        /// </summary>
        /// <param name="incoming"></param>
        private void DetermineLanguage(string incoming)
        {
            //call the language detector from the azure library 
            //hand it a batch of lists containing the data 
            //NOTE: this is currently the only method of doing this with the 
            //Azure libraries
            LanguageBatchResult langRes = apiClient.DetectLanguage(
                new BatchInput(
                    new List<Input>()
                    {
                        new Input("1", incoming) 
                    }));
            //iterate through results 
            foreach (var document in langRes.Documents)
            {
                //Output the detected language
                Console.WriteLine("Language: {0}", document.DetectedLanguages[0].Name);
                language = document.DetectedLanguages[0].Iso6391Name; //assign the language to a class variable for later use
            }
        }
        /// <summary>
        /// determine the key phrases in incoming text
        /// </summary>
        /// <param name="incoming"></param>
        private void DetermineKeyPhrases(string incoming)
        {
            //call the key phrase detector from the azure library 
            KeyPhraseBatchResult PhRes = apiClient.KeyPhrases(
                new MultiLanguageBatchInput(
                    new List<MultiLanguageInput>()
                    {
                        //use the language code determined by DetermineLanguage()
                        new MultiLanguageInput(language, "1", incoming)
                    }));
            //iterate through results 
            foreach (var document in PhRes.Documents)
            {
                Console.WriteLine("Key phrases:");
                //iterate through key phrases
                foreach (string keyphrase in document.KeyPhrases)
                {
                    Console.WriteLine("\t" + keyphrase);
                }
            }
        }
        /// <summary>
        /// use the Azure libraries to determine the sentiment of user input 
        /// </summary>
        /// <param name="incoming"></param>
        private void DetermineSentiment(string incoming)
        {
            //create a class intem to hold the incoming results
            //and call the Sentiment function of the api library 
            //this function takes the arguement of a Multi language batch input
            SentimentBatchResult result = apiClient.Sentiment(
                new MultiLanguageBatchInput(
                    new List<MultiLanguageInput>()
                    {
                        //use the language code determined by DetermineLanguage()
                        new MultiLanguageInput(language,"0", incoming)
                    }));
            //iterate through results 
            foreach (var document in result.Documents)
            {
                //output the sentiment determined by the api
                Console.WriteLine("Sentiment Score: {0:0.00}", document.Score);
            }
        }
    }
}
