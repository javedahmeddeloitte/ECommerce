using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Model.ResponseModel
{
    public class ProductResponeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? SKU { get; set; }
        public string ParentCategoryName { get; set; }
        public string SubCategoryName { get; set; }
    }
}
