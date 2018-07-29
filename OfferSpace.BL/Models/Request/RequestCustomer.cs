using OfferSpace.BL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfferSpace.BL.Models
{
    public class RequestCustomer : IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public long? RequestId { get; set; }
        public Request Request { get; set; }
        public long? CustomerId { get; set; }
        public UserProfile Customer { get; set; }
        public DateTime ScheduleOn { get; set; }
        public bool MarkAsDeleted { get; set; }
        public ICollection<RequestCustomerDiscusion> RequestCustomerDiscusions { get; set; }

        public RequestCustomer()
        {
            RequestCustomerDiscusions = new List<RequestCustomerDiscusion>();
        }
    }
}
