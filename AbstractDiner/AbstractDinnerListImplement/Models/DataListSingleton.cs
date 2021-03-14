using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractDinnerListImplement.Models
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        
        public List<Component> Components { get; set; }
        
        public List<Order> Orders { get; set; }
        
        public List<Snack> Snacks { get; set; }
        
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Snacks = new List<Snack>();
        }
        
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }

}
