using BookingRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BookingRapidApi.Models;
using System.Globalization;

namespace BookingRapidApi.Controllers
{
    [Route("[controller]")]
    public class UIController : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();

        }

        [HttpGet("GetId/{cityName}")]
        public async Task<IActionResult> GetId(string cityName)
        {
            int destinationId;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={cityName}"),
                Headers =
            {
                { "x-rapidapi-key", "471bf090bdmshd83ec1be5c8e366p1d7e70jsn7c2bf78b26dc" },
                { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
            },
            };

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var jsonBody = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<Destination>(jsonBody);
            string destination = values.data?.Where(x => x.country == "Turkey").Select(x => x.dest_id).FirstOrDefault();
            if (!string.IsNullOrEmpty(destination))
            {
                destinationId = Convert.ToInt32(destination);
                return Ok(destinationId);
            }
            return NotFound("Belirtilen şehir için Türkiye'de sonuç bulunamadı.");
        }


        [HttpGet("GetFilterHotels/{destid}/{arrivalDate}/{departureDate}/{adults}/{room}")]
        public async Task<IActionResult> GetFilterHotels(string destid, DateTime arrivalDate, DateTime departureDate, int adults, int room)
        {
            DateTime parsedArrivalDate = arrivalDate;
            DateTime parsedDepartureDate = departureDate;

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={destid}&search_type=CITY&arrival_date={parsedArrivalDate:yyyy-MM-dd}&departure_date={parsedDepartureDate:yyyy-MM-dd}&adults={adults}&room_qty={room}&page_number=1&units=metric&temperature_unit=c"),
                Headers =
        {
            { "x-rapidapi-key", "471bf090bdmshd83ec1be5c8e366p1d7e70jsn7c2bf78b26dc" },
            { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
        },
            };

            try
            {
                using (var response2 = await client2.SendAsync(request2))
                {
                    response2.EnsureSuccessStatusCode();
                    var jsonBody2 = await response2.Content.ReadAsStringAsync();
                    Console.WriteLine("API Yanıtı: " + jsonBody2);

                    // JSON'u FilterHotel türüne deserialize et
                    var filterHotel = JsonConvert.DeserializeObject<FilterHotel>(jsonBody2);

                    // filterHotel null değilse ve data.hotels varsa devam et
                    if (filterHotel == null || filterHotel.data == null || filterHotel.data.hotels == null)
                    {
                        return StatusCode(500, "API yanıtı beklenen formatta değil: Otel listesi bulunamadı.");
                    }

                    // data.hotels kısmını al ve istemciye dön
                    return Ok(filterHotel.data.hotels);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("RenderHotels")]
        public IActionResult RenderHotels([FromBody] List<FilterHotel.Hotel> hotels)
        {
            return ViewComponent("_RoomsViewComponentPartial", new { hotels });
        }



    }
}
