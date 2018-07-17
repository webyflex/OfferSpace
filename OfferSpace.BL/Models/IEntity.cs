using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Models
{
    public interface IEntity<T>
    {
        T Id { get; set; }

        bool MarkAsDeleted { get; set; }
    }
}
