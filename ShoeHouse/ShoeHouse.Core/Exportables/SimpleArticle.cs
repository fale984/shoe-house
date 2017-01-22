﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeHouse.Core.Exportables
{
    /// <summary>
    ///  Intermediate class to export Article entities with the required fields
    /// </summary>
    public class SimpleArticle
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public int total_in_shelf { get; set; }

        public int total_in_vault { get; set; }

        public string store_name { get; set; }
    }
}
