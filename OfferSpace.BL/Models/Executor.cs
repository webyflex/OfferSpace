using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Models
{
    public class Executor : User, IEntity<string>
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public long LocationId { get; set; }
        public Location Location { get; set; }

        public bool MarkAsDeleted { get; set; }

        //public ICollection<Catalog> Catalogs { get; set; }

        //public ICollection<RequestCustomer> RequestCustomers { get; set; }

        //public Executor()
        //{
        //    Catalogs = new List<Catalog>();
        //    RequestCustomers = new List<RequestCustomer>();
        //}
    }
}
