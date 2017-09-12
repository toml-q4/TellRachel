using System;

namespace TellRachel.Models.CommonMedicine
{
    public class CommonMedicineModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Maker { get; set; }

        public string ProductOverview { get; set; }

        public string Dosage { get; set; }

        public string Ingredients { get; set; }

        public string Caution { get; set; }

        public string Warning { get; set; }

        public string PurchaseUrl { get; set; }

        public string ProductUrl { get; set; }
    }
}
