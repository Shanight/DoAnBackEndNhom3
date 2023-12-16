namespace HololiveWeb.API.Models{
    public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    
        // Thêm các trường khác nếu cần
    }
}