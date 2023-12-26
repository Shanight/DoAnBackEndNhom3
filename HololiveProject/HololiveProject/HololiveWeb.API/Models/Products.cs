using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HololiveWeb.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
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
        [NotMapped]
        public IFormFile Img1up { get; set; }
        [NotMapped]
        public IFormFile Img2up { get; set; }
        [NotMapped]
        public IFormFile Img3up { get; set; }

        // Thêm các trường khác nếu cần
    }
}