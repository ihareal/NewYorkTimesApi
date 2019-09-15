using System;

namespace NewYorkTimesApi.Views
{
    /// <summary>
    /// Represents article view model
    /// </summary>
    public class ArticleView
    {
        /// <summary>
        /// Heading (Title)
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// Updated date & time
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Link (url)
        /// </summary>
        public string Link { get; set; }

    }
}
