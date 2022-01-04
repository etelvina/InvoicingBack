namespace Data
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public int IdState { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public int Stock { get; set; }
    }
}
