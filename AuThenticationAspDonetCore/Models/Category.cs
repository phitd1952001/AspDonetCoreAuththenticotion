﻿using System.ComponentModel.DataAnnotations;

namespace AuThenticationAspDonetCore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        public string Description { get; set; }
    }
}