namespace Hololive.Web.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string TotalPrice { get; set; }

     
    }
}
