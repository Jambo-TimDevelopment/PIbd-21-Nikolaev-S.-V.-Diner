using AbstractDinerBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractDinerBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    [DataContract]
    public class SnackViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SnackName { get; set; }
        
        [DataMember]
        [Column(title: "Цена", width: 50)]
        public decimal Price { get; set; }
        
        [DataMember]
        public Dictionary<int, (string, int)> SnackComponents { get; set; }
    }
}
