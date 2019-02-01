using System;
using System.Collections.Generic;
using System.Text;

namespace SE.Catalog.Models
{
    public class DeviceFamily : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
