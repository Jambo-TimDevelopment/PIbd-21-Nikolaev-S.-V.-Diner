﻿using AbstractDinerBusinessLogic.Enums;
using System;
using System.ComponentModel;
namespace AbstractDinerBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderViewModel
    {
        public int Id { get; set; }

        
        public int SnackId { get; set; }
        
        
        [DisplayName("Изделие")]
        public string SnackName { get; set; }
        
        [DisplayName("Количество")]
        public int Count { get; set; }
        
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
        
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
