using Shop_Kataev.Data.Models;

namespace Shop_Kataev.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
        public int Add(Items Item);
    }
}
