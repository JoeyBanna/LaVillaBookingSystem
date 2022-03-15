using LaVillaHotelBookingSystem.Services.IService;
using Models;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace LaVillaHotelBookingSystem.Services
{
    public class CreateBookingService : ICreatingBookingService
    {
        private readonly HttpClient _httpClient;

        public CreateBookingService(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }

        public async Task<CreateCustomerBooking> createBooking(CreateCustomerBooking customerBooking)
        {
            try
            {
                var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelBookings";
                var json = JsonConvert.SerializeObject(customerBooking);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, data);
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    
                    var hotelBooking = JsonConvert.DeserializeObject<CreateCustomerBooking>(content);
                    return hotelBooking;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<CreateCustomerBooking>> getAllBooking()
        {
            try
            {
    
                var response = await _httpClient.GetAsync("https://psl-app-vm3/HotelAdminAPI/api/HotelBookings");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var hotelrooms = JsonConvert.DeserializeObject<IEnumerable<CreateCustomerBooking>>(content);
                    return hotelrooms;
                }
                return new List<CreateCustomerBooking>();
            }
            catch (Exception ex)
            {
                throw;
            }



        }

        public async Task<CreateCustomerBooking> getAllBookingById(string Id)
        {
            
                var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelBookings" + Id;
                var response = await _httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                   
                    var hotelroom = JsonConvert.DeserializeObject<CreateCustomerBooking>(content);
                    return hotelroom;
                }
                else
                {
                    var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                    throw new Exception(errorModel.ErrorMessage);
                }
            



        }
        public async Task<customerBookingDTO> createBookingDT(customerBookingDTO customerBooking)
        {
                var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelBookings";
                var json = JsonConvert.SerializeObject(customerBooking);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, data);
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {

                    var hotelBooking = JsonConvert.DeserializeObject<customerBookingDTO>(content);
                    return hotelBooking;
                }
                return null;

           
        }
    }
}
