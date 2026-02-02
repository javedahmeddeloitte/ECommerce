using CatalogService.Business.Inteface;
using CatalogService.Model.Model;
using CatalogService.Model.ResponseModel;
using CatalogService.Repository.Inteface;
using CatalogService.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Business.Service
{
    public class CatalogQueryService : ICatalogQueryService
    {
        private readonly ICatalogReadRepository _repo;

        public CatalogQueryService(ICatalogReadRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<ProductCategoryEntity>> GetCategories()
            => _repo.GetCategories();

        public Task<IEnumerable<ProductResponeModel>> GetProductsByCategory(Guid id)
            => _repo.GetProductsByCategory(id);

        public Task<ProductResponeModel?> GetProductById(Guid id)
            => _repo.GetProductById(id);

        public async Task<IEnumerable<SubCategoryResponseModel>> GetSubCategories()
        {
            var response  = await _repo.GetSubCategories();
            return response;
        }

        public async Task<IEnumerable<ProductResponeModel>> GetProductBySubCategories(int id)
        {
            var response = await _repo.GetProductBySubCategories(id);
            if(!response.Any())
                return Enumerable.Empty<ProductResponeModel>();
            return response;
        }

  
    }

}
