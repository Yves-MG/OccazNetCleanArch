using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccazNet.Core.Entities
{
    public  class Message :BaseEntity
    {
        public Guid SenderId { get; set; } 
        public required User Sender { get; set; }
        public required Guid ReceiverId { get; set; }
        public required User Receiver { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}
