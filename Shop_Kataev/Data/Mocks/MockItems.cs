using Shop_Kataev.Data.Interfaces;
using Shop_Kataev.Data.Models;

namespace Shop_Kataev.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategories _category = new MockCaregorys();

        public IEnumerable<Items> AllItems {
            get 
            {
                return new List<Items>()
                {
                    new Items() {
                        Id = 0,
                        Name = "Смартфон Apple iPhone 16 Pro Max 256 ГБ черный",
                        Description = "iPhone 16 Pro Max создан вместе с Apple Intelligence, персональной интеллектуальной системой, которая помогает вам писать, выражать себя и выполнять задачи без усилий. Благодаря новаторской защите конфиденциальности вы можете быть уверены, что никто другой не сможет получить доступ к вашим данным — даже Apple. ",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/500/500/c61450e8925f55042ebd96993cd543e0/9286da569d27aabbc02281390acc90a90d1e3a3ae90d90f58510810c9e6870b3.jpg.webp",
                        Price = 121999,
                        Category = _category.AllCategorys.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 1,
                        Name = "ПК ARDOR GAMING NEO M143",
                        Description = "ПК ARDOR GAMING NEO M143 поставляется без установленной ОС. Конфигурация модели собрана на базе 6-ядерного процессора Intel Core i5-12400F, который способен одновременно обрабатывать до 12 вычислительных потоков информации.",
                        Img = "https://c.dns-shop.ru/thumb/st4/fit/500/500/9409d1572800ed85c2936db1a27a4ce7/40a36afea37242b3e2faa935725e81ee56b364f6dc40aea2e41807e2f614b67a.jpg.webp",
                        Price = 68299,
                        Category = _category.AllCategorys.Where(x => x.Id == 1).First()
                    },
                    
                };
            }
        }

        public int Add(Items Item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Items item)
        {
            throw new NotImplementedException();
        }
    }
}
