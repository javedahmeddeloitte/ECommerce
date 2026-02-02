using CatalogService.Business.Inteface;
using CatalogService.CQRS.Commands;
using CatalogService.Model.ResponseModel;
using CatalogService.Repository.DBModels;
using CatalogService.Repository.Inteface;


namespace CatalogService.Business.Service
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly IProductWriteRepository _repo;

        public ProductCommandService(IProductWriteRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> CreateAsync(CreateProductCommand cmd)
        {
            var prod = new Product
            {
                Id = Guid.NewGuid(),
                CategoryId = cmd.CategoryId,
                Name = cmd.Name,
                Description = cmd.Description,
                Price = cmd.Price,
                Stock = cmd.Stock,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                SubCategoryId = cmd.SubCategoryId
            };

            await _repo.AddAsync(prod);
            return prod.Id;
        }

        public async Task<Product> UpdateAsync(UpdateProductCommand cmd)
        {
            var prod = new Product
            {
                Id = cmd.Id,
                CategoryId = cmd.CategoryId,
                Name = cmd.Name,
                Description = cmd.Description,
                Price = cmd.Price,
                Stock = cmd.Stock,
            };

            await _repo.UpdateAsync(prod);
            return prod;
        }

        public async Task DisableAsync(DisableProductCommand cmd)
        {
            await _repo.DisableAsync(cmd.Id);
        }
    }

}
