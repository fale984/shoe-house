using ShoeHouse.Core.Exportables;
using ShoeHouse.Core.Managers;
using ShoeHouse.Web.Filters;
using ShoeHouse.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ShoeHouse.Web.Controllers
{
    [BasicAuthentication]
    public class ArticlesController : ExtendedResponseController
    {
        public ArticleManager articlesManager = new ArticleManager();

        public ArticlesResponse Get()
        {
            var articles = articlesManager.GetArticles();
            //return Success("articles", articles);
            return new ArticlesResponse(articles);
        }

        public ArticleResponse Get(int id)
        {
            var article = articlesManager.GetArticle(id);

            if (article == null)
            {
                throw new CustomHttpException(404);
            }

            //return Success("article", article);
            return new ArticleResponse(article);
        }

        [Route("services/articles/stores/{id}")]
        public ArticlesResponse GetFromStore(int id)
        {
            var articles = articlesManager.GetStoreArticles(id);
            //return Success("articles", articles);
            return new ArticlesResponse(articles);
        }
    }
}
