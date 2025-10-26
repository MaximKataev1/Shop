using Microsoft.AspNetCore.Mvc;

namespace Shop_Kataev.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index() 
        {
            return Redirect("/Items/List");
        }
    }
}
