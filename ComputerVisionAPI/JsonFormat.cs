using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComputerVisionAPI
{
    public class JsonFormat
    {
        /// <summary>
        /// Convert JSON to plain text using Newtonsoft.Json
        /// </summary>
        /// <param name="jsonObject"></param>
        public static void JsonToText(dynamic jsonObject)
        {
            //Deserialize the json from the arguement 
            dynamic dynamDeserializeObjectJson = JsonConvert.DeserializeObject(jsonObject);
            int counter = 0;
            //iterate through the specific region of the deserialized json
            foreach (var lines in dynamDeserializeObjectJson.regions)
            {
                try
                {
                    //iterate through the next layer
                    foreach (var words in lines.lines)
                    {
                        //iterate through the layer that has the desired data 
                        foreach (var text in words.words)
                        {
                            Console.Write("{0} ",text.text);

                        }
                    }
                    
                }
                catch (Exception e)
                {
                    //

                    Console.WriteLine(e);
                   // throw;
                }
            }
        }
    }
}
