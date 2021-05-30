using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractDinerBusinessLogic.BindingModels
{
    public class WarehouseRefillBindingModel
    {
        public int WarehouseId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
