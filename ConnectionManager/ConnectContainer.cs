using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionManager
{
    public class ConnectContainer
    {
        //private variables for holding pertinent information 
        private string subKey = "";
        private string basicURL = "";
        private string keyTag = "Ocp-Apim-Subscription-Key";
        private string queryParameters = "";
        /// <summary>
        /// This constructor ensures that the project will have the full
        /// Range of information required for any API library to connect to 
        /// the corresponding API
        /// </summary>
        /// <param name="key"></param>
        /// <param name="urlBase"></param>
        /// <param name="query"></param>
        public ConnectContainer(string key, string urlBase, string query)
        {
            this.subKey = key;
            this.basicURL = urlBase;
            this.queryParameters = query;
        }
        //The following three functions serve as accessors for the private data of this class 
        public string getSubKey(){
            return this.subKey;
        }
        public string getBasicURL(){
            return this.basicURL;
        }
        public string getKeyTag(){
            return this.keyTag;
        }
        public string getQueryParameters(){
            return this.queryParameters;
        }
        /// <summary>
        /// puts together the basic url supplies with the desired parameters to get a functional url 
        /// </summary>
        /// <returns></returns>
        public string getFullUrl(){
            string URL = this.basicURL + "?" + this.queryParameters;
            return URL;
        }
    }
}
