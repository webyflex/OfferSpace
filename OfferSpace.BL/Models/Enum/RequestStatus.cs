using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Models.Enum
{
    public enum RequestStatus
    {
        New=1,
        Pending=2,
        Active=3,
        Completed=4,
        Canceled=5,
        Archived=6
    }
}
