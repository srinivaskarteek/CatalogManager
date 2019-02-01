using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SE.Catalog.Models
{
    public class PageNSort
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;        
        public string Sort { get; set; }
        public SortOrder SortOrder { get; set; } = SortOrder.Asc;
    }
    public enum SortOrder {
        Asc,
        Desc
    }
}
