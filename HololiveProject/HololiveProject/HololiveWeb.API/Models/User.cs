namespace HololiveWeb.API.Models{
    public class User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    // Thêm các trường khác nếu cần
}
}