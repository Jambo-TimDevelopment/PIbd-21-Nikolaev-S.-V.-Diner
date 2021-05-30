using System.ComponentModel.DataAnnotations;

namespace AbstractDinerDatabaseImplement.Models
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении изделия
    /// </summary>
    public class SnackComponent
    {
        public int Id { get; set; }

        public int SnackId { get; set; }
        
        public int ComponentId { get; set; }
        
        [Required]
        public int Count { get; set; }
        
        public virtual Component Component { get; set; }
        
        public virtual Snack Snack { get; set; }
    }
}