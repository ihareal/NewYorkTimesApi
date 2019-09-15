using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewYorkTimesApi.Interfaces
{
    /// <summary>
    /// Describes IGetInfo class
    /// </summary>
    public interface IGetInfo
    {
        /// <summary>
        /// Requests NYT api for getting json file
        /// </summary>
        /// <param name="section">Section name</param>
        /// <returns>Json</returns>
        string DownloadJson(string section);
    }
}
