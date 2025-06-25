using BookingRapidApi.CitiesEnum;
using Microsoft.AspNetCore.Mvc;

namespace BookingRapidApi.ViewComponents
{
    public class _BookingViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cities = Enum.GetValues(typeof(Cities.City))
                             .Cast<Cities.City>()
                             .Select(c => new { Id = (int)c, Name = c.ToString() })
                             .ToList();

            ViewBag.Cities = cities;

            return View();
            
        }
    }
}
