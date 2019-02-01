using System.Collections.Generic;

namespace SE.Catalog.Models
{
    public class Vendor : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }        
    }
}
