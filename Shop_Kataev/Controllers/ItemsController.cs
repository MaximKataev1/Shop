using Microsoft.AspNetCore.Mvc;
using Shop_Kataev.Data.Interfaces;
using Shop_Kataev.Data.Models;
using Shop_Kataev.Data.ViewModell;

namespace Shop_Kataev.Controllers
{
    public class ItemsController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        private IItems IAllItems;
        private ICategories IAllCategorys;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems IAllItems, ICategories IAllCategorys, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment) {
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";
            // получаем предметы
            VMItems.Items = IAllItems.AllItems;
            // получаем категории
            VMItems.Categorys = IAllCategorys.AllCategorys;
            // запоминаем выбранную категорию
            VMItems.SelectCategory = id;
            return View(VMItems);
        }

        // метод добавления предмета
        [HttpGet]
        public ViewResult Add() 
        {
            IEnumerable<Categories> Categorys = IAllCategorys.AllCategorys;

            return View(Categorys);
        }

        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory) 
        {
            if (files != null) 
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = "/img/" + Path.GetFileName(files.FileName);
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categories() { Id = idCategory };

            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Update?id=" + id);

        }
    } 
}
