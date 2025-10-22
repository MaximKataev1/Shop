using Microsoft.AspNetCore.Mvc;
using Shop_Kataev.Data.Interfaces;

namespace Shop_Kataev.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategories IAllCategorys;

        public ItemsController(IItems IAllItems, ICategories IAllCategorys) {        
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
        }

        public ViewResult List() 
        {
            ViewBag.Title = "Страница с предметами";

            var cars = IAllItems.AllItems;
            return View(cars);
        }
 
    }
}
