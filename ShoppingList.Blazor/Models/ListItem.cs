using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Blazor.Models
{
    public class ListItem
    {
        public Guid Id { get; set; }

        [Required]
        public string Item { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
