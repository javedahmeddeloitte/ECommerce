using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.CQRS.Commands
{
    // CATEGORY
    public record CreateCategoryCommand(string Name, string Slug);
    public record CreateSubCategoryCommand(string Name, Guid parentCategoryId);

    public record DisableCategoryCommand(Guid Id);

    // PRODUCT
    public record CreateProductCommand(
        Guid CategoryId,
        string Name,
        string? Description,
        decimal Price,
        int Stock,
        int SubCategoryId
    );

    public record UpdateProductCommand(
        Guid Id,
        Guid CategoryId,
        string Name,
        string? Description,
        decimal Price,
        int Stock,
        string? SKU
    );

    public record DisableProductCommand(Guid Id);


}
