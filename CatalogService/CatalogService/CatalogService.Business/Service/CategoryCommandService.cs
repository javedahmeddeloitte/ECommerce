using CatalogService.Business.Inteface;
using CatalogService.CQRS.Commands;
using CatalogService.Model.Model;
using CatalogService.Model.ResponseModel;
using CatalogService.Repository.DBModels;
using CatalogService.Repository.Inteface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Business.Service
{
    public class CategoryCommandService : ICategoryCommandService
    {
        private readonly ICategoryWriteRepository _repo;

        public CategoryCommandService(ICategoryWriteRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> CreateAsync(CreateCategoryCommand cmd)
        {
            var cat = new ProductCategory
            {
                Id = Guid.NewGuid(),
                Name = cmd.Name,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(cat);
            return cat.Id;
        }

        public async Task CreateSubCategoryAsync(CreateSubCategoryCommand cmd)
        {
            var cat = new SubCategory
            {
                CategoryName = cmd.Name,
                ParentCategory = cmd.parentCategoryId
            };

            await _repo.AddSubCategoryAsync(cat);
        }

        public async Task DisableAsync(DisableCategoryCommand cmd)
        {
            await _repo.DisableAsync(cmd.Id);
        }

        public async Task<StockUpdateResponseModel> ReserveOrFail(List<StockUpdateModel> items)
        {
            var ok = await _repo.ReserveBulkAsync(items);
            if (ok)
            {
                return new StockUpdateResponseModel
                {
                    IsSuccess = true,
                    Message = "Stock fulfliment done"
                };
            }
            return new StockUpdateResponseModel
            {
                IsSuccess = false,
                Message = "OUT_OF_STOCK"
            };
        }
    }

}
