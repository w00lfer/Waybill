namespace Waybill.Models
{
    public class Localisation : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }
}
