using ShoeHouse.Core.Exportables;
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
    /// Service controller to expose Store items
    /// Requires basic authentication for access
    /// Returns objects with wrapper according to the requirements
    /// </summary>
    [BasicAuthentication]
    public class StoresController : ApiController
    {
        private StoresManager storesManager = new StoresManager();

        /// <summary>
        /// List all Store items
        /// </summary>
        /// <returns>Store list</returns>
        public StoresResponse Get()
        {
            var stores = storesManager.GetStores();

            return new StoresResponse(stores);
        }

        /// <summary>
        /// Find Store by Id
        /// </summary>
        /// <param name="id">Id to search</param>
        /// <returns>Store if found, or custom error</returns>
        public StoreResponse Get(int? id)
        {
            //If the id is not integer or is not provided return bad request
            if (!id.HasValue)
            {
                throw new CustomHttpException(400);
            }

            var store = storesManager.GetStore(id.Value);

            //If the store does not exists, return not found
            if (store == null)
            {
                throw new CustomHttpException(404);
            }

            return new StoreResponse(store);
        }
    }
}
