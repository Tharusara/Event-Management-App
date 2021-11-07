namespace EventApp.Api.Models
{
    public class ServiceSupplier
    {
        public virtual Service Service { get; set; }
        public virtual int ServiceId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual int SupplierId { get; set; }
    }
}
