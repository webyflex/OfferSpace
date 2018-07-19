using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Models
{
    public class Location : IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public long? ParentId { get; set; }
        public Location Parent { get; set; }

        //public bool MarkAsDeleted { get; set; }

        public ICollection<Location> Childrens { get; set; }

        //public ICollection<Executor> Executors { get; set; }
        //public ICollection<Request> Requests { get; set; }
        public Location()
        {
            Childrens = new List<Location>();
            //Executors = new List<Executor>();
            //Requests = new List<Request>();
        }
    }
}
