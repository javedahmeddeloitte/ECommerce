using CatalogService.Model.Model;
using CatalogService.Repository.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Repository.Inteface
{
    public interface ICategoryWriteRepository
    {
        Task AddAsync(ProductCategory entity);
        Task AddSubCategoryAsync(SubCategory entity);
        Task DisableAsync(Guid id);
        Task<bool> ReserveBulkAsync(List<StockUpdateModel> items);
    }
}
