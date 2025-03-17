using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccazNet.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid AdId { get; set; }
        public Ad Ad { get; set; }
        public Guid BuyerId { get; set; } 
        public User Buyer { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
    }
}
