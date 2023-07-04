

using System.ComponentModel.DataAnnotations.Schema;

namespace SEDC.PizzaApp.Refactored.Domain
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
