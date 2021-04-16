using AbstractDinerBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractDinerBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        
        public string ProductName { get; set; }
        
        public int Count { get; set; }
        
        public decimal Sum { get; set; }
        
        public OrderStatus Status { get; set; }
    }
}
