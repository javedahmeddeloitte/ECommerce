using CatalogService.Model.Model;
using CatalogService.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Repository.Inteface
{
    public interface ICatalogReadRepository
    {
        Task<IEnumerable<ProductResponeModel>> GetProductsByCategory(Guid categoryId);
        Task<ProductResponeModel?> GetProductById(Guid id);
        Task<IEnumerable<ProductCategoryEntity>> GetCategories();
        Task<IEnumerable<SubCategoryResponseModel>> GetSubCategories();
        Task<IEnumerable<ProductResponeModel>> GetProductBySubCategories(int id);
    }
}
