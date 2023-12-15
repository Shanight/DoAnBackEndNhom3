using Microsoft.Extensions.Logging;

namespace Hololive.Web.Models
{
    public class CombinedData
    {
        public List<Products> Products { get; set; }
        public List<Event> Events { get; set; }
    }
}
