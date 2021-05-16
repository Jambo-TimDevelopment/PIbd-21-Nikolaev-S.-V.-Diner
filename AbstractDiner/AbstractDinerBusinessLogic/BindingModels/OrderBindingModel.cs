using AbstractDinerBusinessLogic.Enums;
using System;

namespace AbstractDinerBusinessLogic.BindingModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int SnackId { get; set; }
<<<<<<< HEAD
        public string SnackName { get; set; }
=======
>>>>>>> parent of dd39dd7... create lab2_hard
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
