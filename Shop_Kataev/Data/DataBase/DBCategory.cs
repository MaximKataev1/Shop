using MySql.Data.MySqlClient;
using Shop_Kataev.Data.Common;
using Shop_Kataev.Data.Interfaces;
using Shop_Kataev.Data.Models;

namespace Shop_Kataev.Data.DataBase
{
    public class DBCategory : ICategories
    {
        public IEnumerable<Categories> AllCategories 
        {
            get 
            {
                List<Categories> categories = new List<Categories>();
                MySqlConnection MySqlConnection = Connection.MySqlOpen();
                MySqlDataReader CategorysData = Connection.MySqlQuery("SELECT * FROM Shop.Categorys ORDER BY `Name`;", MySqlConnection);
                while (CategorysData.Read()) 
                {
                    categories.Add(new Categories()
                    {
                        Id = CategorysData.IsDBNull(0) ? -1 : CategorysData.GetInt32(0),
                        Name = CategorysData.IsDBNull(1) ? null : CategorysData.GetString(1),
                        Description = CategorysData.IsDBNull(2) ? null : CategorysData.GetString(2)
                    });
                }
                return categories;
            }
        }
    }
}
