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
    public class StoresController : ApiController
    {
        private StoresManager storesManager = new StoresManager();

        public IEnumerable<SimpleStore> Get()
        {
            return storesManager.GetStores();
        }

        public SimpleStore Get(int id)
        {
            return storesManager.GetStore(id);
        }
    }
}
