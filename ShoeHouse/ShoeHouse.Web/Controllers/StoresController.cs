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
            return Success("store", store);
        }
    }
}
