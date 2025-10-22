using Shop_Kataev.Data.Models;

namespace Shop_Kataev.Data.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Categories> AllCategorys { get; }
    }
}
