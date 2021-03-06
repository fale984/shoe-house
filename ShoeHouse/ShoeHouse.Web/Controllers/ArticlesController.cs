﻿using ShoeHouse.Core.Exportables;
using ShoeHouse.Core.Managers;
using ShoeHouse.Web.Filters;
using ShoeHouse.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoeHouse.Web.Controllers
{
    /// <summary>
    /// Service controller to expose Article items
    /// Requires basic authentication for access
    /// Returns objects with wrapper according to the requirements
    /// </summary>
    [BasicAuthentication]
    public class ArticlesController : ApiController
    {
        public ArticleManager articlesManager = new ArticleManager();

        /// <summary>
        /// List all Article items
        /// </summary>
        /// <returns>Article list</returns>
        public ArticlesResponse Get()
        {
            var articles = articlesManager.GetArticles();

            return new ArticlesResponse(articles);
        }

        /// <summary>
        /// Find Article by id
        /// </summary>
        /// <param name="id">Id to search</param>
        /// <returns>Article if found, or custom error</returns>
        public ArticleResponse Get(int? id)
        {
            //If the id is not integer or is not provided return bad request
            if (!id.HasValue)
            {
                throw new CustomHttpException(400);
            }

            var article = articlesManager.GetArticle(id.Value);

            //If the article does not exist, return custom error
            if (article == null)
            {
                throw new CustomHttpException(404);
            }

            return new ArticleResponse(article);
        }

        /// <summary>
        /// List all Articles in the store specified
        /// </summary>
        /// <param name="id">Id of the store</param>
        /// <returns>Article list</returns>
        [Route("services/articles/stores/{id}")]
        public ArticlesResponse GetFromStore(int? id)
        {
            //If the id is not integer or is not provided return bad request
            if (!id.HasValue)
            {
                throw new CustomHttpException(400);
            }

            var articles = articlesManager.GetStoreArticles(id.Value);

            //If the store does not exist, return not found message
            if (articles == null)
            {
                throw new CustomHttpException(404);
            }

            return new ArticlesResponse(articles);
        }
    }
}
