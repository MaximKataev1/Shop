using MySql.Data.MySqlClient;
using Shop_Kataev.Data.Common;
using Shop_Kataev.Data.Interfaces;
using Shop_Kataev.Data.Models;

namespace Shop_Kataev.Data.DataBase
{
    public class DBCategory : ICategories
    {
        public IEnumerable<Categories> AllCategorys 
        {
            get 
            {
                // объявляем список категорий
                List<Categories> categories = new List<Categories>();
                // открываем подключение к базе данных
                MySqlConnection MySqlConnection = Connection.MySqlOpen();
                // получаем данные из таблицы категорий
                MySqlDataReader CategorysData = Connection.MySqlQuery("SELECT * FROM Shop.Categorys ORDER BY `Name`;", MySqlConnection);
                // читаем данные
                while (CategorysData.Read()) 
                {
                    // добавляем в список категорий 
                    categories.Add(new Categories()
                    {
                        Id = CategorysData.IsDBNull(0) ? -1 : CategorysData.GetInt32(0),
                        Name = CategorysData.IsDBNull(1) ? null : CategorysData.GetString(1),
                        Description = CategorysData.IsDBNull(2) ? null : CategorysData.GetString(2)
                    });
                }
                // возвращаем список категорий
                return categories;
            }
        }
    }
}
