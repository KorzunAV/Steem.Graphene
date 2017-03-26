using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Graphene.Core
{
    public class RPC
    {

        public Dictionary<string,string> ExecuteRemoteCall(string name)
        {
            var api_id = 0;
            var num_retries = -1;

            var query = "";//{ "method": "call", "params": [api_id, name, list(args)], "jsonrpc": "2.0", "id": self.get_request_id()}
            var r = RPSExec(query);

            return null;
        }

        protected string RPSExec(string query)
        {
            //вызов веб сокета
            return string.Empty;
        }

        protected static string GetResponseFromApi(string url, string query)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";//Можно POST
                httpWebRequest.UserAgent = "unknown";
                httpWebRequest.ServerCertificateValidationCallback = (sender, cert, chain, errors) => true;

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var rStr = httpResponse.GetResponseStream();

                if (rStr == null)
                    throw new NullReferenceException("rStr");

                using (var streamReader = new StreamReader(rStr))
                {
                    //ответ от сервера
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception exception)
            {
                //Log.Error(exception);
            }
            return string.Empty;
        }

       
    }
}
