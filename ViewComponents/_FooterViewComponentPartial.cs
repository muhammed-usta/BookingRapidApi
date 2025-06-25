using Microsoft.AspNetCore.Mvc;

namespace BookingRapidApi.ViewComponents
{
    public class _FooterViewComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
