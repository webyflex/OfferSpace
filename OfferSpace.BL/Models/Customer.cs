using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Models
{
    public class Customer : IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public string UserId { get; set; }
        public long? CompanyId { get; set; }
        public Company Company { get; set; }
        //public User User { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Image { get; set; }

        public bool MarkAsDeleted { get; set; }


    }
}
