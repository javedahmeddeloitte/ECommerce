using CatalogService.Model.Model;
using CatalogService.Repository.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Repository.Inteface
{
    public interface IProductWriteRepository
    {
        Task AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DisableAsync(Guid id);
    }
}
