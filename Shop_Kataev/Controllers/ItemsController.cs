using Microsoft.AspNetCore.Mvc;
using Shop_Kataev.Data.Interfaces;
using Shop_Kataev.Data.ViewModell;

namespace Shop_Kataev.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategories IAllCategorys;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems IAllItems, ICategories IAllCategorys) {        
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
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
 
    }
}
