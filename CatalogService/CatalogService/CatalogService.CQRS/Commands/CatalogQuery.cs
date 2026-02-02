using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.CQRS.Commands
{
    public record GetAllCategoriesQuery();
    public record GetProductsByCategoryQuery(Guid CategoryId);
    public record GetProductByIdQuery(Guid Id);

}
