﻿using AbstractDinerBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractDinerDatabaseImplement.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual Snack Snack{ get; set; }

        public virtual Implementer Implementer { get; set; }

        public int? ImplementerId { get; set; }

        public int SnackId { get; set; }
        
        public string OrderName { get; set; }
        
        public string SnackName { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }
        
        public DateTime? DateImplement { get; set; }
    }
}
