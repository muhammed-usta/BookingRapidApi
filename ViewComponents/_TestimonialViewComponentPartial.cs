using Microsoft.AspNetCore.Mvc;

namespace BookingRapidApi.ViewComponents
{
    public class _TestimonialViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke ()
        {
            return View();
        }
    }
}
