using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccazNet.Core.Entities
{
    public  class Ad:BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
    }
}
