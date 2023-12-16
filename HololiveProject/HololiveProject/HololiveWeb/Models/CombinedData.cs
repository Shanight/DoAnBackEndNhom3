using HololiveWeb.API.Models;
using System.Collections.Generic;

namespace HololiveWeb.Models
{
    public class CombinedData
    {
        public List<Product> Products { get; set; }
        public List<Event> Events { get; set; }        
    }
}