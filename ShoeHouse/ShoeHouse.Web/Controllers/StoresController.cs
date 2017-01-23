using ShoeHouse.Core.Exportables;
using ShoeHouse.Core.Managers;
using ShoeHouse.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoeHouse.Web.Controllers
{
    [BasicAuthentication]
    public class StoresController : ExtendedResponseController
    {
        private StoresManager storesManager = new StoresManager();

        public IHttpActionResult Get()
        {
            var stores = storesManager.GetStores();
            return Success("stores", stores);
        }

        public IHttpActionResult Get(int id)
        {
            var store = storesManager.GetStore(id);

            if (store == null)
            {
                throw new CustomHttpException(404);
            }

            return Success("store", store);
        }
    }
}
