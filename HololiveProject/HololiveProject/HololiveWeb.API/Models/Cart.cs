namespace HololiveWeb.API.Models{
    public class Cart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public string TotalPrice { get; set; }
    // Thêm các trường khác nếu cần
}
}