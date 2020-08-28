using System;

namespace BusinessManager.Models.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Barcode { get; set; }
        public Guid SerialNumber { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        public bool Warranty { get; set; }
        public DateTime WarrantyExpirationDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public string Others { get; set; }

    }
}
