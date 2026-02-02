using CatalogService.Model.Model;
using CatalogService.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Business.Inteface
{
    public interface ICatalogQueryService
    {
        Task<IEnumerable<ProductCategoryEntity>> GetCategories();
        Task<IEnumerable<ProductResponeModel>> GetProductsByCategory(Guid categoryId);
        Task<IEnumerable<SubCategoryResponseModel>> GetSubCategories();
        Task<ProductResponeModel?> GetProductById(Guid id);
        Task<IEnumerable<ProductResponeModel?>> GetProductBySubCategories(int id);
    }
}
