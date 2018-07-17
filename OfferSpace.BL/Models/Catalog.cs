using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Models
{
    public class Catalog : IEntity<long>
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        public long? ParentId { get; set; }
        public Catalog Parent { get; set; }

        public ICollection<Catalog> Childrens { get; set; }

        public ICollection<Executor> Executors { get; set; }

        public ICollection<Request> Requests { get; set; }

        public bool MarkAsDeleted { get; set; }

        public Catalog()
        {
            Executors = new List<Executor>();
            Childrens = new List<Catalog>();
            Requests = new List<Request>();
        }
    }
}
