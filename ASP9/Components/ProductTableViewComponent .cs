using ASP9.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP9.Components
{
    public class ProductTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<ComponentModel> data)
        {
            return View(data);
        }
    }
}
