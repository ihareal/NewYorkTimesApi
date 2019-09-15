using System;

namespace NewYorkTimesApi.Views
{
    /// <summary>
    /// Represents JSON view model
    /// </summary>
    public class JSONView
    {
        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Copyright
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Section
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Last updated date
        /// </summary>
        public DateTime Last_Updated { get; set; }

        /// <summary>
        /// Num results
        /// </summary>
        public string Num_Results { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        /// Results
        /// </summary>
        public Result[] Results { get; set; }
    }
}
