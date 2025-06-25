using BookingRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace BookingRapidApi.Controllers
{
    public class FilterHotelController : Controller
    {
      

        public async Task<IActionResult> Index()
        {
            int destinationId = -755070;
            string arrivalDateStr = new DateTime(2025, 4, 23).ToString("yyyy-MM-dd");
            string depatureDateStr = new DateTime(2025, 5, 22).ToString("yyyy-MM-dd");
            int adults = 2;
            int room = 1;

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={destinationId}&search_type=CITY&arrival_date={arrivalDateStr}&departure_date={depatureDateStr}&adults={adults}&room_qty={room}&page_number=1&units=metric&temperature_unit=c"),


                Headers =
    {
        { "x-rapidapi-key", "471bf090bdmshd83ec1be5c8e366p1d7e70jsn7c2bf78b26dc" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var jsonBody2 = await response2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<FilterHotel>(jsonBody2);
                return View(values2.data);
            }
        
    }
    }
}
