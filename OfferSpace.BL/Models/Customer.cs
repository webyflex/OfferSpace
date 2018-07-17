using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Models
{
    public class Customer : User, IEntity<string>
    {
        //public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Image { get; set; }

        public ICollection<Request> Requests { get; set; }

        public bool MarkAsDeleted { get; set; }

        public Customer()
        {
            Requests = new List<Request>();
        }

    }
}
