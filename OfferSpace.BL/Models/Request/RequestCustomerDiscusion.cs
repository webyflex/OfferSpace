using OfferSpace.BL.Core;
using System.ComponentModel.DataAnnotations;

namespace OfferSpace.BL.Models
{
    public class RequestCustomerDiscusion : IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public long RequestCustomerId { get; set; }
        public RequestCustomer RequestCustomer { get; set; }
        public string Comment { get; set; }
        public bool ChangePrice { get; set; }
        public bool ChangeDate { get; set; }
        public bool MarkAsDeleted { get; set; }
        public bool AgreedFromCustomer { get; set; }
        public bool AgreedFromExecutor { get; set; }
    }
}
