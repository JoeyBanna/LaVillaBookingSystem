using LaVillaHotelBookingSystem.Services.IService;
using Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace LaVillaHotelBookingSystem.Services
{
    public class HotelRoomTypeService: IHotelRoomTypeService
    {
        private readonly HttpClient _httpClient;

        public HotelRoomTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<HotelRoomType>> GetHotelRoomByType()
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/Codes/GetCodesByType/hotrt";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {

                var hotelroom = JsonConvert.DeserializeObject<IEnumerable<HotelRoomType>>(content);
                return hotelroom;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }

        }
    }
}
