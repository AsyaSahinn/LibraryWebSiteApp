using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models.Entity.Base
{
    public class TEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
