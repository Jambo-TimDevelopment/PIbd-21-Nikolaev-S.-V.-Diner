using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractDinerBusinessLogic.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    [DataContract]
    public class SnackBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string SnackName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> SnackComponents { get; set; }
    }
}
