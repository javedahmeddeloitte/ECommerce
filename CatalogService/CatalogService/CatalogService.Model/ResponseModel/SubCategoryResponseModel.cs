using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Model.ResponseModel
{
    public class SubCategoryResponseModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public Guid ParentCategory { get; set; }
    }
}
