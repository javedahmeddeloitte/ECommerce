using System;
using System.Collections.Generic;

namespace CatalogService.Repository.DBModels;

public partial class SubCategory
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public Guid? ParentCategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
