using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccazNet.Core.Entities
{
    public class Location : BaseEntity
    {
        public string Address { get; set; } // Adresse complète entrée par l'utilisateur
        public string City { get; set; }
        public string Region { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<Ad> Ads { get; set; }
    }
}
