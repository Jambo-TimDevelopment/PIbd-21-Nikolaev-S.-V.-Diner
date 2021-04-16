using AbstractDinerBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractDinerBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        
        public string Title { get; set; }
        
        public List<ComponentViewModel> Components { get; set; }

        public List<SnackViewModel> Snacks { get; set; }
    }
}
