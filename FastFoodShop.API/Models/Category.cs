﻿using System.ComponentModel.DataAnnotations;

namespace FastFoodShop.API.Models
{
    public class Category
    {
        [Key]
        public int Id {  get; set; }    
        public string Name { get; set; }   
        public string ImageUrl { get; set; }
    }
}
