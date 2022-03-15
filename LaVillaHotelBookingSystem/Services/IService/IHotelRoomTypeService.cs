using Models;

namespace LaVillaHotelBookingSystem.Services.IService
{
    public interface IHotelRoomTypeService
    {
        public  Task<IEnumerable<HotelRoomType>> GetHotelRoomByType();
    }
}
