using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccazNet.Core.Entities
{
    public class Favorite : BaseEntity
    {
        public required Guid UserId { get; set; }
        public required User User { get; set; }
        public Guid AdId { get; set; }
        public required Ad Ad { get; set; }
    }
}
