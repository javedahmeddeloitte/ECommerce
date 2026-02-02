using System;
using System.Collections.Generic;

namespace CatalogService.Repository.DBModels;

public partial class Product
{
    public Guid Id { get; set; }

    public Guid CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? SubCategoryId { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual SubCategory? SubCategory { get; set; }
}
