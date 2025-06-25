using Microsoft.AspNetCore.Mvc;

namespace BookingRapidApi.ViewComponents
{
    public class _StatsViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
