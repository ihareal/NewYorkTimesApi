using Nancy;
using NewYorkTimesApi.Interfaces;

namespace NewYorkTimesApi
{
    /// <summary>
    /// Represents class for endpoints
    /// </summary>
    public class HomeController : NancyModule
    {
        private readonly IArticleService _articleService;

        /// <summary>
        /// Initializes new instance of HomeModule class & contains enpdoints
        /// </summary>
        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;

            // Base endpoint
            Get("/", _ => "[{Status: True}]");
            
            // Returns articles filtered by section name
            Get("/list/{section}", param => _articleService.GetListBySection(param.section));

            // Returns first article filetered by section name
            Get("/list/{section}/first", param => _articleService.GetFirstArticleBySection(param.section));

            // Returns articles filetered by section and updated date
            Get("/list/{section}/{updatedDate}", param => _articleService.GetListBySectionAndUpdatedDate(param.section, param.updatedDate));

            // Returns article by short url
            Get("/article/{shortUrl}", param => _articleService.GetArticleByShortUrl(param.shortUrl));

            // Returns articles count per day
            Get("/group/{section}", param => _articleService.GetArticleCountGroupedByDate(param.section));

        }
    }
}
