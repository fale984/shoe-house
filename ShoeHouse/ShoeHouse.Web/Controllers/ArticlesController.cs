﻿using ShoeHouse.Core.Exportables;
using ShoeHouse.Core.Managers;
using ShoeHouse.Web.Filters;
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

        public IHttpActionResult Get()
        {
            var articles = articlesManager.GetArticles();
            return Success("articles", articles);
        }

        public IHttpActionResult Get(int id)
        {
            var article = articlesManager.GetArticle(id);

            if (article == null)
            {
                throw new CustomHttpException(404);
            }

            return Success("article", article);
        }

        [Route("services/articles/stores/{id}")]
        public IHttpActionResult GetFromStore(int id)
        {
            var articles = articlesManager.GetStoreArticles(id);
            return Success("articles", articles);
        }
    }
}
