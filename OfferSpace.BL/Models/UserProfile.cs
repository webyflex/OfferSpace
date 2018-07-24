using OfferSpace.BL.Core;
using System.ComponentModel.DataAnnotations;

namespace OfferSpace.BL.Models
{
    public class UserProfile : IEntity<long>
    {
        //[Key]
        public long Id { get; set; }
        public string UserId { get; set; }
        public long? CompanyId { get; set; }
        public Company Company { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Image { get; set; }

        public bool MarkAsDeleted { get; set; }
    }
}
