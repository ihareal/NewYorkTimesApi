using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NewYorkTimesApi;
using NewYorkTimesApi.Logic;
using NewYorkTimesApi.Views;

namespace NewYorkTimesTests
{
    [TestClass]
    public class ArticlesServiceTest
    {
        #region Fields

        private ArticleService _articleService;

        private GetInfo _getInfo;

        #endregion

        #region TestInitialize

        [TestInitialize]
        public void TestInitialize()
        {
            _getInfo = new GetInfo();
            _articleService = new ArticleService(_getInfo);
        }

        #endregion

        #region TestMethods

        [TestMethod]
        public void GetFirstArticleBySectionTest_ShouldReturnTrue()
        {
            // act

            var result = JsonConvert.DeserializeObject<ArticleView>(_articleService.GetFirstArticleBySection("books"));

            // assert        

            Assert.AreEqual(result.GetType().Name, nameof(ArticleView));
        }

        [TestMethod]
        public void GetArticleCountByDateTest_ShouldReturnTrue()
        {
            // act 

            var result = JsonConvert.DeserializeObject<ArticleGroupByDateView>(_articleService.GetArticleCountGroupedByDate("books"));

            // assert

            Assert.AreEqual(result.GetType().Name, nameof(ArticleGroupByDateView));
        }

        #endregion
    }
}
