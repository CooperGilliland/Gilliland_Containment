using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.SpeechRecognition;

namespace BingSpeechAPI
{
    public class SpeechtoText
    {
        private DataRecognitionClient _dataRecClient;
        private SpeechRecognitionMode _speechMode = SpeechRecognitionMode.ShortPhrase;
        private string _language = "en-US";

        public SpeechtoText(string apiKey)
        {
            _dataRecClient = SpeechRecognitionServiceFactory.CreateDataClient(_speechMode, _language, apiKey);           
        }

        public async void StartAudioFileToText(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                int bytesRead = 0;
                byte[] buffer = new byte[1024];
                try
                {
                    do
                    {
                        bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                        _dataRecClient.SendAudio(buffer, bytesRead);
                        
                    } while (bytesRead > 0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    _dataRecClient.EndAudio();
                }
            }
        }

        public void RecieveResponse()
        {
            
        }
    }
}
