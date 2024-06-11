﻿namespace CRUDAPP.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Product> products { get; set; } = new List<Product>();
    }
    

}
