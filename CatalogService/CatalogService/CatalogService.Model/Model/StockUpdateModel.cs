using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Model.Model
{
    public class StockUpdateModel
    {
        public Guid ProductId { get; set; }
        public int quantity { get; set; }
    }
}
