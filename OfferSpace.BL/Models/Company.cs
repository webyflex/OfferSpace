using OfferSpace.BL.Core;

namespace OfferSpace.BL.Models
{
    public class Company : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
