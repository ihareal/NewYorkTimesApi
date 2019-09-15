using System;

namespace NewYorkTimesApi.Views
{
    /// <summary>
    /// Represents result array section in JSON file
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Section
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Subsection
        /// </summary>
        public string Subsection { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Abstract
        /// </summary>
        public string Abstract { get; set; }

        /// <summary>
        /// ByLine
        /// </summary>
        public string ByLine { get; set; }
        
        /// <summary>
        /// Item type
        /// </summary>
        public string item_type { get; set; }

        /// <summary>
        /// Updated date
        /// </summary>
        public DateTime Updated_Date { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime Created_Date { get; set; }

        /// <summary>
        /// Published date
        /// </summary>
        public DateTime Published_Date { get; set; }

        /// <summary>
        /// Result item shorted url
        /// </summary>
        public string Short_Url { get; set; }
    }
}
