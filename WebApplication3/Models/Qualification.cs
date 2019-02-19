using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}