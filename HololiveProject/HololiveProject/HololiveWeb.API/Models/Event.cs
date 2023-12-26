using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HololiveWeb.API.Models{
    public class Event
{
    public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
    public DateTime Date { get; set; }
    public string Img1 { get; set; }
    public string Img2 { get; set; }
    public string Img3 { get; set; }
    public string Preview1 { get; set; }
    public string Preview2 { get; set; }
    public string Preview3 { get; set; }
    public string Preview4 { get; set; }
    public string Preview5 { get; set; }
        // Thêm các trường khác nếu cần
        [NotMapped]
        public IFormFile Img1up { get; set; }
        [NotMapped]
        public IFormFile Img2up { get; set; }
        [NotMapped]
        public IFormFile Img3up { get; set; }
    }
}