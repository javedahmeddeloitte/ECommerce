using CatalogService.CQRS.Commands;
using CatalogService.Model.Model;
using CatalogService.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Business.Inteface
{
    public interface ICategoryCommandService
    {
        Task<Guid> CreateAsync(CreateCategoryCommand cmd);
        Task CreateSubCategoryAsync(CreateSubCategoryCommand cmd);
        Task DisableAsync(DisableCategoryCommand cmd);
        Task<StockUpdateResponseModel> ReserveOrFail(List<StockUpdateModel> updateModels);
    }
}
