using Models;

namespace LaVillaHotelBookingSystem.Services.IService
{
    public interface ICreatingBookingService
    {
        public Task <CreateCustomerBooking> createBooking(CreateCustomerBooking customerBooking);
        public Task<IEnumerable<CreateCustomerBooking>> getAllBooking();
        public Task<CreateCustomerBooking> getAllBookingById(string Id);
        public Task<customerBookingDTO> createBookingDT(customerBookingDTO customerBooking);
    }
}
