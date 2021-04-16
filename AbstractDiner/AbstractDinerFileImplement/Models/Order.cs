﻿using AbstractDinerBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractDinnerFileImplement.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int SnackId { get; set; }
        public string OrderName { get; set; }
        public string SnackName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
