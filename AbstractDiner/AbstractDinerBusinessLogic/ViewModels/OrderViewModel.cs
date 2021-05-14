using AbstractDinerBusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractDinerBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderViewModel
    {

        [DataMember]
        [DisplayName("Исполнитель")]
        public string ImplementerFIO { get; set; }

        public int? ImplementerId { get; set; }

        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public int ClientId { get; set; }
        
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int SnackId { get; set; }

        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }

        [DataMember]
        [DisplayName("Изделие")]
        public string SnackName { get; set; }

        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }

        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DataMember]
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DataMember]
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
