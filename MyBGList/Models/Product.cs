using System.ComponentModel.DataAnnotations; 
namespace MyBGList.Models {
     public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } ="";
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }="";
}
}