using System;
using System.Collections.Generic;

namespace AbstractDinerBusinessLogic.ViewModels
{
    public class ReportProductComponentViewModel
    {
        public string SnackName { get; set; }
        
        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Components { get; set; }
}
}
