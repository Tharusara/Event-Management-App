namespace EventApp.Api.Models
{
    public class PackageService
    {
        public virtual Service Service { get; set; }
        public virtual int ServiceId { get; set; }
        public virtual Package Package { get; set; }
        public virtual int PackageId { get; set; }
    }
}
