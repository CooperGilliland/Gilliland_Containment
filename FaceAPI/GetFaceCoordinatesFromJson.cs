using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FaceAPI
{
    public class GetFaceCoordinatesFromJson
    {
        /// <summary>
        /// Convert JSON to plain text using Newtonsoft.Json
        /// TODO: for future projects, determine if it is more efficient to seperate the 
        /// TODO: cont. Deserialization from the formatted outputS 
        /// </summary>
        /// <param name="jsonObject"></param>
        public static void JsonToText(string jsonObject)
        {
            //Deserialize the json from the arguement 
            dynamic dynamDeserializeObjectJson = JsonConvert.DeserializeObject(jsonObject);
            int faceTotal = 0; //set current total number of faces 
            //iterate through the deserialized json
            foreach (var face in dynamDeserializeObjectJson)
            {
                faceTotal++; //add to the total number of faces 
                Console.WriteLine("Coordinates for Face #{0}", faceTotal); //output which face is about to be displayed 
                //output the coordinates of the current face 
                Console.WriteLine("Top: {0}\nLeft: {1}\nWidth: {2}\nHeight: {3}\n", face.faceRectangle.top,
                    face.faceRectangle.left, face.faceRectangle.width, face.faceRectangle.height);
            }
        }
        public static dynamic Deserialize(string jsonObject)
        {
            dynamic dynamDeserializeObjectJson = JsonConvert.DeserializeObject(jsonObject);
            return dynamDeserializeObjectJson;
        }
    }
}