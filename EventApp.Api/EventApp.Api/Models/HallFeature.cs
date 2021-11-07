namespace EventApp.Api.Models
{
    public class HallFeature
    {
        public virtual Feature Feature { get; set; }
        public virtual int FeatureId { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual int HallId { get; set; }
    }
}
