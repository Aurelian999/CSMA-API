using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSMA_API.Domain
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Ammount of time in minutes
        /// </summary>
        public int Duration { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Number of sessions: 1 - One-time session; >1 - Subscription package
        /// </summary>
        /// TODO add default value 1
        //[DefaultValue(1)]
        public int Sessions { get; set; }

        public byte[]? DisplayImage { get; set; }

    }
}
