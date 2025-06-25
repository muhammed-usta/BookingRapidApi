using Microsoft.AspNetCore.Mvc;

namespace BookingRapidApi.ViewComponents
{
    public class _InstaViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
