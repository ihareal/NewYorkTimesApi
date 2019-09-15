using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewYorkTimesApi.Interfaces
{
    /// <summary>
    /// Describes ArticleService class
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// Returns articles list filtered by section name
        /// </summary>
        /// <param name="section">Section name</param>
        /// <returns>Article view model list serialized in JSON</returns>
        string GetListBySection(string section);

        /// <summary>
        /// Returns first article by section name
        /// </summary>
        /// <param name="section"></param>
        /// <returns>Article view model serialize in JSON</returns>
        string GetFirstArticleBySection(string section);

        /// <summary>
        /// Returns articles filtered by section & updated date
        /// </summary>
        /// <param name="section">Section name</param>
        /// <param name="inputDateTime">Input datetime</param>
        /// <returns>Article view model list serialized in JSON</returns>
        string GetListBySectionAndUpdatedDate(string section, string inputDateTime);

        /// <summary>
        /// Returns article by short url in home section
        /// </summary>
        /// <param name="shortUrl">Short url</param>
        /// <returns>ArticleView object</returns>
        string GetArticleByShortUrl(string shortUrl);

        /// <summary>
        /// Returns article count ordered by date
        /// </summary>
        /// <param name="section">Section name</param>
        /// <returns>ArticleGroupByDateView object</returns>
        string GetArticleCountGroupedByDate(string section);
    }
}
