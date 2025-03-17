using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccazNet.Core.Entities
{
    public class Review : BaseEntity
    {
        public Guid ReviewerId { get; set; }
        public required User Reviewer { get; set; }
        public Guid ReviewedUserId { get; set; }
        public required User ReviewedUser { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
