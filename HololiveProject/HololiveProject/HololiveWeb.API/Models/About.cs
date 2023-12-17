namespace HololiveWeb.API.Models{
    public class About
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public required string Description { get; set; }
    // Thêm các trường khác nếu cần
}
}