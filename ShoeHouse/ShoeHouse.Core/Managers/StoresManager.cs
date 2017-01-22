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
    /// Transforms the Store entities from the database to SimpleStore
    /// </summary>
    public class StoresManager
    {
        private ShoesDbEntities context = new ShoesDbEntities();

        /// <summary>
        /// Get all stores
        /// </summary>
        /// <returns>List of simple stores</returns>
        public List<SimpleStore> GetStores()
        {
            var stores = context.Stores.Select(x => new SimpleStore
            {
                id = x.Id,
                name = x.Name,
                address = x.Address
            });

            return stores.ToList();
        }

        /// <summary>
        /// Find store by id
        /// </summary>
        /// <param name="storeId">Item to search</param>
        /// <returns>Store if exists</returns>
        public SimpleStore GetStore(int storeId)
        {
            var store = context.Stores
                .Where(x => x.Id == storeId)
                .Select(x => new SimpleStore
                {
                    id = x.Id,
                    name = x.Name,
                    address = x.Address
                })
                .FirstOrDefault();

            return store;
        }
    }
}
