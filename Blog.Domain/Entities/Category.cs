using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int? ParentCategoryId { get; private set; }
        public List<Category> Childs { get; private set; } = new List<Category>();

        // Navigation property for the parent category
        public Category ParentCategory { get; private set; }
        // Constructor
        public Category()
        {

        }
        public Category(string name, int? parentCategoryId = null)
        {
            SetName(name);
            
            ParentCategoryId = parentCategoryId;
        }
        public void Edit(string name, int ParentCategory)
        {
            Name = name;
            ParentCategoryId = ParentCategory;
        }

        // Business Rules
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be empty.");
            Name = name;
        }

        public void AddChildCategory(string name, int? parentCategoryId)
        {
            var child = new Category(name, parentCategoryId)
            {
                ParentCategoryId = this.Id
            };
            Childs.Add(child);
        }
    }
}
 