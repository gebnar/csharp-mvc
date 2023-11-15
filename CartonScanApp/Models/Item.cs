using System;

namespace CartonScanApp.Models {
    public class Item {
        public int ID { get; set; }
        public string Barcode { get; set; }
        public int CartonId { get; set; }
        public virtual Carton Carton { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}