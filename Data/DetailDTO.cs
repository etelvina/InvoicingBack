namespace Data
{
    public class DetailDTO
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
        public decimal Importe { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Vat { get; set; }
    }
}
