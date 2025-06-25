using Microsoft.AspNetCore.Mvc;

namespace BookingRapidApi.ViewComponents
{
    public class _HomeSliderViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
