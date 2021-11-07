using System.Collections.Generic;

namespace EventApp.Api.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<HallFeature> HallFeatures { get; set; }
    }
}
