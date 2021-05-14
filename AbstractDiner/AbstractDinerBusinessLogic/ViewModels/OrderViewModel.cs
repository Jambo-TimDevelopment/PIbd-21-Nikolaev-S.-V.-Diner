using AbstractDinerBusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractDinerBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public int ClientId { get; set; }
        
        [DataMember]
        public int SnackId { get; set; }
        
        [DataMember]
        public int? ImplementerId { get; set; }
        
        [DataMember]
        public string ClientFIO { get; set; }
        
        [DataMember]
        public string SnackName { get; set; }
        
        [DataMember]
        public string ImplementerFIO { get; set; }
        
        [DataMember]
        public int Count { get; set; }
        
        [DataMember]
        public decimal Sum { get; set; }
        

        [DataMember]
        public OrderStatus Status { get; set; }
        
        [DataMember]
        public DateTime DateCreate { get; set; }
        
        [DataMember]
        public DateTime? DateImplement { get; set; }

    }
}
