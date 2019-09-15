using Newtonsoft.Json;
using NewYorkTimesApi.Interfaces;
using NewYorkTimesApi.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewYorkTimesApi.Logic
{
    /// <summary>
    /// Represents ArticleService class
    /// </summary>
    public class ArticleService : IArticleService
    {
        #region Fields

        private readonly IGetInfo _getInfo;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes new ArtcleService class instance
        /// </summary>
        /// <param name="articleService"><see cref="IArticleService"/></param>
        public ArticleService(IGetInfo getInfo)
        {
            _getInfo = getInfo;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public string GetListBySection(string section)
        {
            // Initialize list to store information there
            List<ArticleView> articleViews = new List<ArticleView>();

            try
            {
            // Get & deserialize JSON file
            var json = JsonConvert.DeserializeObject<JSONView>(_getInfo.DownloadJson(section));

            // Manually build model
            // TODO: Mappings
            foreach (var article in json.Results)
            {
                articleViews.Add(new ArticleView
                {
                    Heading = article.Title,
                    Updated = article.Updated_Date,
                    Link = article.Short_Url
                });
            }
            }
            catch (NullReferenceException exception)
            {
                throw new NullReferenceException($"{nameof(JSONView)} {exception.Message}");
            }

            // Return serialized from list to JSON response
            return JsonConvert.SerializeObject(articleViews);
        }

        /// <inheritdoc />
        public string GetFirstArticleBySection(string section)
        {
            // Initialize list to store information there
            List<ArticleView> articleViews = new List<ArticleView>();

            try
            {
                // Get & deserialize JSON file
                var json = JsonConvert.DeserializeObject<JSONView>(_getInfo.DownloadJson(section));

                // Get first element

                var article = json.Results.FirstOrDefault();

                // Manually build model
                // TODO: Mappings
                articleViews.Add(new ArticleView
                {
                    Heading = article.Title,
                    Updated = article.Updated_Date,
                    Link = article.Short_Url
                });
            }            

            catch (NullReferenceException exception)
            {
                throw new NullReferenceException($"{nameof(JSONView)} {exception.Message}");
            }

            // Return serialized from list to JSON response
            return JsonConvert.SerializeObject(articleViews);
        }

        /// <inheritdoc />
        public string GetListBySectionAndUpdatedDate(string section, string inputDateTime)
        {
            // Initialize list to store information there
            List<ArticleView> articleViews = new List<ArticleView>();

            DateTime dateTime = DateTime.ParseExact(inputDateTime, "yyyy-MM-dd", null);

            try
            {
                // Get & deserialize JSON file
                var json = JsonConvert.DeserializeObject<JSONView>(_getInfo.DownloadJson(section));

                // x.Updated_Date.ToString("yyyy-MM-dd").Equals(dateTime.ToString("yyyy-MM-dd"))
                json.Results = json.Results.Where(x => x.Updated_Date.ToString("yyyy-MM-dd").Equals(dateTime.ToString("yyyy-MM-dd"))).ToArray();

                foreach (var article in json.Results)
                {
                    articleViews.Add(new ArticleView
                    {
                        Heading = article.Title,
                        Updated = article.Updated_Date,
                        Link = article.Short_Url
                    });
                }
            }            

            catch (NullReferenceException exception)
            {
                throw new NullReferenceException($"{nameof(JSONView)} {exception.Message}");
            }

            // Return serialized from list to JSON response
            return JsonConvert.SerializeObject(articleViews);
        }


        /// <inheritdoc />
        public string GetArticleByShortUrl(string shortUrl)
        {
            // Initialize list to store information there
            List<ArticleView> articleView = new List<ArticleView>();

            try
            {
                // Get & deserialize JSON file
                var json = JsonConvert.DeserializeObject<JSONView>(_getInfo.DownloadJson("home"));

                var article = json.Results.FirstOrDefault(x => x.Short_Url == $"https://nyti.ms/{shortUrl}");

                articleView.Add(new ArticleView
                {
                    Heading = article.Title,
                    Updated = article.Updated_Date,
                    Link = article.Short_Url
                });
            }

            catch (NullReferenceException exception)
            {
                throw new NullReferenceException($"{nameof(JSONView)} {exception.Message}");
            }                  

            return JsonConvert.SerializeObject(articleView);
        }

        /// <inheritdoc />
        public string GetArticleCountGroupedByDate(string section)
        {
            List<ArticleGroupByDateView> articleCountGroupByDateList = new List<ArticleGroupByDateView>();
            try
            {
                // Get & deserialize JSON file
                var json = JsonConvert.DeserializeObject<JSONView>(_getInfo.DownloadJson(section));

                // Group by date
                articleCountGroupByDateList = json.Results.GroupBy(x => x.Created_Date.ToString("yyyy-MM-dd"))
                    .Select(y => new ArticleGroupByDateView { Date = y.Key, Total = y.Count() }).ToList();
            }

            catch (NullReferenceException)
            {
                throw new NullReferenceException($"{nameof(JSONView)} is null");
            }

            return JsonConvert.SerializeObject(articleCountGroupByDateList);
        }

        #endregion
        
    }
}
