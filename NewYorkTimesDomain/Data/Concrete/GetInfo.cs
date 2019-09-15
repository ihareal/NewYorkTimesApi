using NewYorkTimesApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NewYorkTimesApi
{
    /// <summary>
    /// Represents class for getting json
    /// </summary>
    public class GetInfo : IGetInfo
    {
        #region Methods

        /// <inheritdoc />
        public string DownloadJson(string section)
        {                  
            using (WebClient webClient = new WebClient())
            {
               // Get string representation of JSON
               var json = webClient.DownloadString($"https://api.nytimes.com/svc/topstories/v2/{section}.json?api-key=k0XA0k0jJGAVuv8Jr5wAIcKDGPuznmRJ");
               return json;
            }
        }

        #endregion

    }
}
