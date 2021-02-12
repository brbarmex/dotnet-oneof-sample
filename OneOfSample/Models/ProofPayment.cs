using System;

namespace OneOfSample.Models
{
    public class ProofPayment
    {
        public Guid Id { get; set; }
        public int Identifier { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
        public DateTime DateBilling { get; set; }
    }
}