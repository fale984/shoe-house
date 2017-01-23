using ShoeHouse.Core.Exportables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace ShoeHouse.Web.Models
{
    [XmlRoot(ElementName = "article_response")]
    public class ArticleResponse
    {
        public SimpleArticle article { get; set; }

        public bool success { get; set; }

        public ArticleResponse()
        {
            success = true;
        }

        public ArticleResponse(SimpleArticle article)
        {
            this.success = true;
            this.article = article;
        }
    }

    [XmlRoot(ElementName = "articles_response")]
    public class ArticlesResponse
    {
        [XmlElement("articles")]
        public List<SimpleArticle> articles { get; set; }

        public bool success { get; set; }

        public int total_elements { get; set; }

        public ArticlesResponse()
        {
            success = true;
            articles = new List<SimpleArticle>();
        }

        public ArticlesResponse(List<SimpleArticle> articles)
        {
            success = true;
            this.articles = articles;
            if (this.articles != null)
            {
                this.total_elements = this.articles.Count;
            }
        }
    }
}