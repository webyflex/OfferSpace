using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Models
{
    public class Company : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
