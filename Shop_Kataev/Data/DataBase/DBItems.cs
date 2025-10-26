using MySql.Data.MySqlClient;
using Shop_Kataev.Data.Common;
using Shop_Kataev.Data.Interfaces;
using Shop_Kataev.Data.Models;

namespace Shop_Kataev.Data.DataBase
{
    public class DBItems : IItems
    {
        public IEnumerable<Categories> Categorys = new DBCategory().AllCategorys;

        public IEnumerable<Items> AllItems
        {
            get
            {
                List<Items> items = new List<Items>();
                MySqlConnection MySqlConnection = Connection.MySqlOpen();
                MySqlDataReader ItemsData = Connection.MySqlQuery("SELECT * FROM Shop.Items ORDER BY `Name`;", MySqlConnection);
                while (ItemsData.Read())
                {
                    items.Add(new Items()
                    {
                        Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                        Name = ItemsData.IsDBNull(1) ? null : ItemsData.GetString(1),
                        Description = ItemsData.IsDBNull(2) ? null : ItemsData.GetString(2),
                        Img = ItemsData.IsDBNull(3) ? null : ItemsData.GetString(3),
                        Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                        Category = ItemsData.IsDBNull(5) ? null : Categorys.Where(x => x.Id == ItemsData.GetInt32(5)).First()
                    });
                }
                MySqlConnection.Close();
                return items;
            }
        }
    }
}
