using LaVillaHotelBookingSystem.Services.IService;
using Models;
using Newtonsoft.Json;

namespace LaVillaHotelBookingSystem.Services
{
    public class HotelRoomService : IHotelRoomService
    {
        private readonly HttpClient _httpClient;

        public HotelRoomService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<HotelRoomDT>> GetHotelRooms(DateTime checkInDate, DateTime CheckOutDate)
        {
            try
            {
                var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelRooms/GetRoomsByCheckInOutDates/"+ checkInDate.ToString("yyyy-MM-dd") + "/" + CheckOutDate.ToString("yyyy-MM-dd");
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var hotelrooms = JsonConvert.DeserializeObject<IEnumerable<HotelRoomDT>>(content);
                    return hotelrooms;
                }
                return new List<HotelRoomDT>();
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public Task<HotelRoomDT> GetHotelRooms(string roomId, string CheckInDate, string CheckOutDate)
        {
            throw new NotImplementedException();
        }
    }
}
