using OfferSpace.BL.Core;
using OfferSpace.BL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfferSpace.BL.Models
{
    public class Request : IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public long? CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; }
        public long? LocationId { get; set; }
        public virtual Location Location { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string Description { get; set; }
        public long? CustomerId { get; set; }
        public UserProfile Customer { get; set; }
        public DateTime ScheduleFrom { get; set; }
        public DateTime ScheduleTo { get; set; }
        public long? RequestCustomerId { get; set; }
        public ICollection<RequestCustomer> RequestCustomer { get; set; }
        public bool MarkAsDeleted { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.New;

        public Request()
        {
            this.RequestCustomer = new List<RequestCustomer>();
        }
    }
}
