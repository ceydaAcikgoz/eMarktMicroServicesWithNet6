namespace eMarkt.Catalog.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductImageURL { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
    }
}
