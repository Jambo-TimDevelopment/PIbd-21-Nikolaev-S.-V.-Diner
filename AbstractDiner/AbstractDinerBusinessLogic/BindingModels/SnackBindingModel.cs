using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractDinerBusinessLogic.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class SnackBindingModel
    {
        public int? Id { get; set; }
        
        public string SnackName { get; set; }
        
        public decimal Price { get; set; }
        
        public Dictionary<int, (string, int)> SnackComponents { get; set; }
    }
}
