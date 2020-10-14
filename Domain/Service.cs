using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMA_API.Domain
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Ammount of time in minutes
        /// </summary>
        public int Duration { get; set; }
        public string Description { get; set; }

    }
}
