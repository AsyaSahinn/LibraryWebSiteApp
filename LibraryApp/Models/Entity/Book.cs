using System.ComponentModel.DataAnnotations;
using LibraryApp.Models.Entity.Base;

namespace LibraryApp.Models.Entity
{
    public class Book : TEntity
    {
        public string? Name { get; set; }

        public string? Author { get; set; }

        public bool IsBorrow { get; set; }

        public string? ImagePath { get; set; }


    }
}
