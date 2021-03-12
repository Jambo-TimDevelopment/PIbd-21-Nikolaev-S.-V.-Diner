﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractDinerBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class SnackViewModel
    {
        public int Id { get; set; }
        
        [DisplayName("Название изделия")]
        public string SnackName { get; set; }
        
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        
        public Dictionary<int, (string, int)> SnackComponents { get; set; }
    }
}
