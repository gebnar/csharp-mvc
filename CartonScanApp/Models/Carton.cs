using System;

namespace CartonScanApp.Models {
    public class Carton {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}