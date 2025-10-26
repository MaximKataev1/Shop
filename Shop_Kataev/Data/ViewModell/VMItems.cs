using Shop_Kataev.Data.Models;

namespace Shop_Kataev.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Categories> Categorys { get; set; }
        public int SelectCategory = 0;
    }
}
