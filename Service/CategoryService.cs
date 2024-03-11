using Microsoft.AspNetCore.Mvc;
using PDP._7_Modul.Vazifa_1.Models;

namespace PDP._7_Modul.Vazifa_1.Service
{
    public class CategoryService
    {
        private static List<Category> Categories =
        [
            new(1, "Drinks", "Cold beverages"),
            new(2, "bla bla", "dadad dasd beverages"),
            new(3, "Vegatables", "Fresh vegatables"),
            new(4, "Fruits", "Fresh fruits"),
            new(5, "Sweets", "Sweets category with chocolate"),
        ];
        public List<Category> GetAll()=> Categories;
        public Category? GetById(int id)
        {
            return Categories.FirstOrDefault(x=>x.Id == id);
        }
        public void Create(int id, string name, string description)
        {
            var category = new Category(id, name, description);
            if (category == null)
            {
                return;
            }
            Categories.Add(category);
        }
        public void Update(Category category)
        {
            var categoryToReplace = Categories.FirstOrDefault(x=> x.Id == category.Id);
            if (categoryToReplace is null) { return; }

            var index = Categories.IndexOf(categoryToReplace);
            Categories[index] = category;
        }
        public void Delete(int id)
        {
            var resultDelete = Categories.FirstOrDefault(x=>x.Id==id);
            if (resultDelete is null) { return;}  
            Categories.Remove(resultDelete);
        }
        
    }
}
