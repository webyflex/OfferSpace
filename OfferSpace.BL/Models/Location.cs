using OfferSpace.BL.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfferSpace.BL.Models
{
    public class Location : IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public long? ParentId { get; set; }
        public Location Parent { get; set; }

        public ICollection<Location> Childrens { get; set; }

        public Location()
        {
            Childrens = new List<Location>();
        }
    }
}
