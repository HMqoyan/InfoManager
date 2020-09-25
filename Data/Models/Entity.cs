using System.ComponentModel.DataAnnotations;

namespace InfoManager.Data.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; protected set; }
    }
}
