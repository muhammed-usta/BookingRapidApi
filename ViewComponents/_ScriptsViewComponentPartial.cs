using Microsoft.AspNetCore.Mvc;

namespace BookingRapidApi.ViewComponents
{
    public class _ScriptsViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
             return View();
        }
    }
}
