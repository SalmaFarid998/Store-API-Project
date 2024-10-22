using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification.ProductSpecs
{
    public class ProductSpecification
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Sort { get; set; }
        public int  PageIndex { get; set; }
        public const int MaxPageSize = 50;
        private int _pageSize;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value>MaxPageSize)?int.MaxValue:value;
        }

    }
}
