using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Model.Model
{
    public class ProductCategoryEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ProductEntity
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }

        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

    }

}
