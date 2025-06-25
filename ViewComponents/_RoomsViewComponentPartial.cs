using BookingRapidApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingRapidApi.ViewComponents
{
    public class _RoomsViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(List<FilterHotel.Hotel> hotels)
        {
            return View(hotels ?? new List<FilterHotel.Hotel>());
        }
    }
}