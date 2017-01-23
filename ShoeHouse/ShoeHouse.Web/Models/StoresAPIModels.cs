using ShoeHouse.Core.Exportables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ShoeHouse.Web.Models
{
    [XmlRoot(ElementName = "store_response")]
    public class StoreResponse
    {
        public SimpleStore store { get; set; }

        public bool success { get; set; }

        public StoreResponse()
        {
            success = true;
        }

        public StoreResponse(SimpleStore store)
        {
            this.success = true;
            this.store = store;
        }
    }

    [XmlRoot(ElementName = "stores_response")]
    public class StoresResponse
    {
        [XmlElement("stores")]
        public List<SimpleStore> stores { get; set; }

        public bool success { get; set; }

        public int total_elements { get; set; }

        public StoresResponse()
        {
            success = true;
            stores = new List<SimpleStore>();
        }

        public StoresResponse(List<SimpleStore> stores)
        {
            success = true;
            this.stores = stores;
            if (this.stores != null)
            {
                this.total_elements = this.stores.Count;
            }
        }
    }
}