namespace HololiveWeb.API.Models{
    public class Event
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    // Thêm các trường khác nếu cần
}
}