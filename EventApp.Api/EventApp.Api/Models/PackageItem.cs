namespace EventApp.Api.Models
{
    public class PackageItem
    {
        public virtual Package Package { get; set; }
        public virtual int PackageId { get; set; }
        public virtual Item Item { get; set; }
        public virtual int ItemId { get; set; }
    }
}
