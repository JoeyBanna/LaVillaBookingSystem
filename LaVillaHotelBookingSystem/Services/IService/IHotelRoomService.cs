using Models;

namespace LaVillaHotelBookingSystem.Services.IService
{
    public interface IHotelRoomService
    {
        public Task<IEnumerable<HotelRoomDT>> GetHotelRooms(DateTime checkInDate, DateTime CheckOutDate);
        public Task<HotelRoomDT> GetHotelRooms(string roomId, string CheckInDate, string CheckOutDate);
    }
}
