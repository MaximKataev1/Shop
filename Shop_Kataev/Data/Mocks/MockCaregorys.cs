using Shop_Kataev.Data.Interfaces;
using Shop_Kataev.Data.Models;

namespace Shop_Kataev.Data.Mocks
{
    public class MockCaregorys : ICategories
    {
        public IEnumerable<Categories> AllCategorys {
            get {
                return new List<Categories>
                {
                    new Categories() {
                        Id = 0,
                        Name = "Смартфоны",
                        Description = "Смартфоны"
                    },
                    new Categories() {
                        Id = 1,
                        Name = "ПК",
                        Description = "Персональные компьютеры"
                    },
                };
            }
        }
    }
}
