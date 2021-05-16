using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractDinnerListImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Snack
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public string SnackName { get; set; }
=======
        public string SnacksName { get; set; }
>>>>>>> parent of dd39dd7... create lab2_hard
        public decimal Price { get; set; }
        public Dictionary<int, int> SnackComponents { get; set; }
    }
}
