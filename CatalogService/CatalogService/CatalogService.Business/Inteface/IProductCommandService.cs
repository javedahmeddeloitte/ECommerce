using CatalogService.CQRS.Commands;
using CatalogService.Model.ResponseModel;
using CatalogService.Repository.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Business.Inteface
{

    public interface IProductCommandService
    {
        Task<Guid> CreateAsync(CreateProductCommand cmd);
        Task<Product> UpdateAsync(UpdateProductCommand cmd);
        Task DisableAsync(DisableProductCommand cmd);
    }
}
