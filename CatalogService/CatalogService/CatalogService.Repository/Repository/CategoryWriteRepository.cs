using CatalogService.Model.Model;
using CatalogService.Repository.DBModels;
using CatalogService.Repository.Inteface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogService.Repository.Repository
{
    public class CategoryWriteRepository : ICategoryWriteRepository
    {

        private readonly CatalogDbContext _db;

        public CategoryWriteRepository(CatalogDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(ProductCategory entity)
        {
            _db.ProductCategories.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddSubCategoryAsync(SubCategory entity)
        {
            _db.SubCategories.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DisableAsync(Guid id)
        {
            var cat = await _db.ProductCategories.FindAsync(id);
            if (cat == null) return;

            cat.IsActive = false;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ReserveBulkAsync(List<StockUpdateModel> items)
        {
            for (int retry = 0; retry < 3; retry++)
            {
                using var tx = await _db.Database.BeginTransactionAsync(
                    System.Data.IsolationLevel.Serializable);

                var ids = items.Select(x => x.ProductId).ToList();

                var products = await _db.Products
                    .Where(p => ids.Contains(p.Id))
                    .ToListAsync();

                if (products.Count != items.Count)
                    return false;

                // check stock
                foreach (var item in items)
                {
                    var p = products.First(x => x.Id == item.ProductId);
                    if (p.Stock < item.quantity)
                    {
                        await tx.RollbackAsync();
                        return false;
                    }

                    p.Stock -= item.quantity;
                }

                try
                {
                    await _db.SaveChangesAsync();
                    await tx.CommitAsync();
                    return true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    await tx.RollbackAsync();
                }
            }

            return false;
        }
    }
}
