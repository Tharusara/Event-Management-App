namespace EventApp.Api.Models
{
    public class ItemSupplier
    {
        public virtual Item Item { get; set; }
        public virtual int ItemId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual int SupplierId { get; set; }
    }
}
