using CatalogService.Model.Model;
using CatalogService.Repository.DBModels;
using CatalogService.Repository.Inteface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Repository.Repository
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        private readonly CatalogDbContext _db;

        public ProductWriteRepository(CatalogDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Product entity)
        {
            _db.Products.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _db.Products.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DisableAsync(Guid id)
        {
            var prod = await _db.Products.FindAsync(id);
            if (prod == null) return;

            prod.IsActive = false;
            await _db.SaveChangesAsync();
        }
    }
}
