using System.Collections.Generic;

namespace BusinessManager.Models.Models
{
    public class Configuration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalPrice { get; set; }
        public string WhoOrdered { get; set; }
        public List<Products> Components { get; set; }
    }
}
