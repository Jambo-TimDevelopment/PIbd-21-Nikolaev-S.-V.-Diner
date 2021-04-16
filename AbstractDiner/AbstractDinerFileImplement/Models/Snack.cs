using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractDinnerFileImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Snack
    {
        public int Id { get; set; }
        
        public string SnackName { get; set; }
        
        public decimal Price { get; set; }
        
        public Dictionary<int, int> SnackComponents { get; set; }
    }
}
