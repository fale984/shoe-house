using ShoeHouse.Core.Exportables;
using ShoeHouse.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoeHouse.Web.Controllers
{
    public class ArticlesController : ApiController
    {
        public ArticleManager articlesManager = new ArticleManager();

        public IEnumerable<SimpleArticle> Get()
        {
            return articlesManager.GetArticles();
        }

        public SimpleArticle Get(int id)
        {
            return articlesManager.GetArticle(id);
        }

        [Route("services/articles/stores/{id}")]
        public IEnumerable<SimpleArticle> GetFromStore(int id)
        {
            return articlesManager.GetStoreArticles(id);
        }
    }
}
