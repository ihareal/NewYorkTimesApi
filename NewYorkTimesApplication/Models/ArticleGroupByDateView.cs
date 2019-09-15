using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewYorkTimesApi.Views
{
    /// <summary>
    /// Represents article by date view model
    /// </summary>
    public class ArticleGroupByDateView
    {
        /// <summary>
        /// Date
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Total count
        /// </summary>
        public int Total { get; set; }

    }
}
