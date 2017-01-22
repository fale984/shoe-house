using ShoeHouse.Core.Exportables;
using ShoeHouse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoeHouse.Core.Managers
{
    /// <summary>
    /// Transforms the Article entities from the database to SimpleArticle
    /// </summary>
    public class ArticleManager
    {
        private ShoesDbEntities context = new ShoesDbEntities();

        /// <summary>
        /// Get all shoes
        /// </summary>
        /// <returns>List of simple articles</returns>
        public List<SimpleArticle> GetArticles()
        {
            var articles = context.Articles.Select(x => new SimpleArticle
            {
                id = x.Id,
                name = x.Name,
                description = x.Description,
                price = x.Price,
                total_in_shelf = x.TotalInShelf,
                total_in_vault = x.TotalInVault,
                store_name = x.Store.Name
            });

            return articles.ToList();
        }

        /// <summary>
        /// Find article by id
        /// </summary>
        /// <param name="articleId">Item to search</param>
        /// <returns>Article if exists</returns>
        public SimpleArticle GetArticle(int articleId)
        {
            var article = context.Articles
                .Where(x => x.Id == articleId)
                .Select(x => new SimpleArticle
                {
                    id = x.Id,
                    name = x.Name,
                    description = x.Description,
                    price = x.Price,
                    total_in_shelf = x.TotalInShelf,
                    total_in_vault = x.TotalInVault,
                    store_name = x.Store.Name
                })
                .FirstOrDefault();

            return article;
        }

        /// <summary>
        /// Get all shoes in the specified store
        /// </summary>
        /// <param name="storeId">Store to search</param>
        /// <returns>Shoes in store, empty if store does not exist</returns>
        public List<SimpleArticle> GetStoreArticles(int storeId)
        {
            var articles = context.Articles
                .Where(x => x.StoreId == storeId)
                .Select(x => new SimpleArticle
                {
                    id = x.Id,
                    name = x.Name,
                    description = x.Description,
                    price = x.Price,
                    total_in_shelf = x.TotalInShelf,
                    total_in_vault = x.TotalInVault,
                    store_name = x.Store.Name
                });

            return articles.ToList();
        }
    }
}
