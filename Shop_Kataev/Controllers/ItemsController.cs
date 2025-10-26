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

        // Метод для отображения страницы добавления нового предмета
        [HttpGet]
        public ViewResult Add() 
        {
            // Получаем список всех категорий для выбора при добавлении предмета
            IEnumerable<Categories> Categorys = IAllCategorys.AllCategorys;
            // Передаём список категорий в представление для отображения в форме
            return View(Categorys);
        }

        // Метод обработки формы добавления нового предмета
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory) 
        {
            // Проверяем, был ли загружен файл изображения
            if (files != null) 
            {
                // Определяем путь до папки img в корне веб-приложения
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                // Полный путь к файлу для сохранения
                var filePath = Path.Combine(uploads, files.FileName);
                // Копируем загруженный файл на сервер (создаём новый файл)
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            // Создаём новый экземпляр предмета и заполняем его свойства из формы
            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = "/img/" + Path.GetFileName(files.FileName);
            newItems.Price = Convert.ToInt32(price);
            // Связываем предмет с категорией по id
            newItems.Category = new Categories() { Id = idCategory };

            // Добавляем предмет в репозиторий и сохраняем возвращаемый id
            int id = IAllItems.Add(newItems);
            // Перенаправляем пользователя на страницу редактирования добавленного предмета
            return Redirect("/Items/Update?id=" + id);

        }

        // Метод для отображения страницы редактирования существующего предмета
        [HttpGet]
        public IActionResult Update(int id)
        {
            // Находим предмет по id из хранилища
            var item = IAllItems.AllItems.FirstOrDefault(x => x.Id == id);
            // Передаём список категорий в ViewBag для выбора в форме редактирования
            ViewBag.Categorys = IAllCategorys.AllCategorys;
            // Возвращаем найденный предмет в представление для редактирования
            return View(item);
        }

        // Метод обработки формы обновления предмета
        [HttpPost]
        public IActionResult Update(int id, string name, string description, IFormFile file, float price, int idCategory)
        {
            // Находим существующий предмет по id
            var existingItem = IAllItems.AllItems.FirstOrDefault(x => x.Id == id);
            if (existingItem == null) return NotFound();

            // Если загружен новый файл изображения и он не пустой
            if (file != null && file.Length > 0)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                Directory.CreateDirectory(uploads);
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                existingItem.Img = "/img/" + fileName;
            }

            // Обновляем остальные свойства предмета значениями из формы
            existingItem.Name = name;
            existingItem.Description = description;
            existingItem.Price = Convert.ToInt32(price);
            existingItem.Category = new Categories() { Id = idCategory };

            // Сохраняем изменения
            IAllItems.Update(existingItem);

            // После обновления перенаправляем на страницу списка предметов
            return RedirectToAction("List");
        }

        // Метод для удаления предмета по id
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Вызываем удаление
            IAllItems.Delete(id);
            // Перенаправляем обратно к списку предметов после удаления
            return RedirectToAction("List");
        }
    } 
}
