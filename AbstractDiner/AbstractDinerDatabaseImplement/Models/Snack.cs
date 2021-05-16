using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractDinerDatabaseImplement.Models
{
    public class Snack
    {
        public int Id { get; set; }

        [Required]
        public string SnackName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("SnackId")]
        public virtual List<SnackComponent> SnackComponents { get; set; }

        [ForeignKey("SnackId")]
        public virtual List<Order> Orders { get; set; }
    }
}
