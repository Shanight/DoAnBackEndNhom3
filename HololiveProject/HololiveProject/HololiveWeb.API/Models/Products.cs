using System.ComponentModel.DataAnnotations.Schema;

namespace HololiveWeb.API.Models{
    public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Catetory { get; set; }
    public string img1 { get; set; }
    public string img2 { get; set; }
    public string img3 { get; set; }
    public string Preview1 { get; set; }
    public string Preview2 { get; set; }
    public string Preview3 { get; set; }
    public string Preview4 { get; set; }
    public string Preview5 { get; set; }
    public decimal Price { get; set; }

        // Thêm các trường khác nếu cần
    }
}