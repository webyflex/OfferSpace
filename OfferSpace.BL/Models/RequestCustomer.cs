using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Models
{
    public class RequestCustomer : IEntity<long>
    {
        [Key]
        public long Id { get; set; }

        //[ForeignKey("RequestId")]
        public long? RequestId { get; set; }
        public Request Request { get; set; }

        public long? ExecutorId { get; set; }
        public Executor Executor { get; set; }

        public DateTime ScheduleOn { get; set; }

        public bool MarkAsDeleted { get; set; }

        //[ForeignKey("RequestCustomerDiscusion")]
        public ICollection<RequestCustomerDiscusion> RequestCustomerDiscusions { get; set; }
        //public RequestCustomerDiscusion RequestCustomerDiscusion { get; set; }

        public RequestCustomer()
        {
            RequestCustomerDiscusions = new List<RequestCustomerDiscusion>();
        }
    }
}
