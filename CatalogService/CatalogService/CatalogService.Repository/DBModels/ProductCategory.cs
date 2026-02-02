using System;
using System.Collections.Generic;

namespace CatalogService.Repository.DBModels;

public partial class ProductCategory
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
