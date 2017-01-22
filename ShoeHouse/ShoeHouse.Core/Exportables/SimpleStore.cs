using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeHouse.Core.Exportables
{
    /// <summary>
    /// Intermediate class to export Store entities with the required fields
    /// </summary>
   public class SimpleStore
    {
        public int id { get; set; }

        public string address { get; set; }

        public string name { get; set; }
    }
}
