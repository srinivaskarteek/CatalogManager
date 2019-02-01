using System;
using System.Collections.Generic;
using System.Text;

namespace SE.Catalog.Models
{
    public class BaseEntity
    {
        public DateTime LastModified { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
