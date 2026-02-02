using CatalogService.Model.Model;
using CatalogService.Model.ResponseModel;
using CatalogService.Repository.Inteface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CatalogService.Repository.Repository
{
    public class CatalogReadRepository : ICatalogReadRepository
    {
        private readonly IDbConnectionFactory _db;

        public CatalogReadRepository(IDbConnectionFactory db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductResponeModel>> GetProductsByCategory(Guid categoryId)
        {
            using var conn = _db.CreateConnection();

            var sql = @"
                    SELECT p.Id, p.Name, p.Price, p.Stock,
                           c.Name AS CategoryName
                    FROM Products p
                    JOIN ProductCategories c ON p.CategoryId = c.Id
                    WHERE p.CategoryId = @categoryId";

            return await conn.QueryAsync<ProductResponeModel>(sql, new { categoryId });
        }

        public async Task<ProductResponeModel?> GetProductById(Guid id)
        {
            using var conn = _db.CreateConnection();

            var sql = @"
                    SELECT p.Id, p.Name, p.Price, p.Stock,
                           c.Name AS ParentCategoryName,
                           s.CategoryName As SubCategoryName
                    FROM Products p
                    JOIN ProductCategories c ON p.CategoryId = c.Id
                    Join SubCategory s ON p.SubCategoryId =  s.Id

                    WHERE p.Id = @id and  p.IsActive = 1";

            return await conn.QuerySingleOrDefaultAsync<ProductResponeModel>(sql, new { id });
        }

        public async Task<IEnumerable<ProductCategoryEntity>> GetCategories()
        {
            using var conn = _db.CreateConnection();

            return await conn.QueryAsync<ProductCategoryEntity>(
                "SELECT * FROM ProductCategories WHERE IsActive = 1");
        }

        public async Task<IEnumerable<SubCategoryResponseModel>> GetSubCategories()
        {
            using var conn = _db.CreateConnection();

            return await conn.QueryAsync<SubCategoryResponseModel>(
                "SELECT * FROM SubCategory ");
        }

        public async Task<IEnumerable<ProductResponeModel>> GetProductBySubCategories(int id)
        {
            using var conn = _db.CreateConnection();

            var sql = @"
                    SELECT p.Id, p.Name, p.Price, p.Stock,
                           c.Name AS ParentCategoryName,
                           s.CategoryName As SubCategoryName
                    FROM Products p
                    JOIN ProductCategories c ON p.CategoryId = c.Id
                    Join SubCategory s ON p.SubCategoryId =  s.Id

                    WHERE p.SubCategoryId = @id and  p.IsActive = 1";

            return await conn.QueryAsync<ProductResponeModel>(sql, new { id });
        }
    }

}
