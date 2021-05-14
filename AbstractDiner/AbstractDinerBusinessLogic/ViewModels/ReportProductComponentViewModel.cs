using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractDinerBusinessLogic.ViewModels
{
    [DataContract]
    public class ReportProductComponentViewModel
    {
        [DataMember]
        public string SnackName { get; set; }

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public List<Tuple<string, int>> Components { get; set; }
}
}
