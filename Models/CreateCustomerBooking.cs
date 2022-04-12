using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CreateCustomerBooking
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Enter Full Name")]
        [StringLength(18,
        ErrorMessage = "Name too long (18 character limit).")]
        public string customerName { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        [Range(1, 10,
        ErrorMessage = "Mobile Number Invalid (1-10) Characters Only.")]
        public string customerMobile { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address")]
        public string customerEmailAddress { get; set; }
        public int amountPaid { get; set; }
        public int balance { get; set; }
        [Required]
        public DateTime checkInDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime checkOutDate { get; set; }= DateTime.Now;
        public HotelRoomDT hotelRoomDT { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
    
        
    }
  public class customerBookingDTO
    {
        [Required(ErrorMessage = "Enter Full Name")]
        [StringLength(50,
        ErrorMessage = "Name too long (18 character limit).")]
        public string customerName { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        [RegularExpression(@"^(\d{10})+$", ErrorMessage = "Invalid Mobile Number")]
        public string customerMobile { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address")]
        public string customerEmailAddress { get; set; }
        public int amountPaid { get; set; }
        public int balance { get; set; }
        public DateTime checkInDate { get; set; } = DateTime.Now;
        public DateTime checkOutDate { get; set; } = DateTime.Now;
        public Guid roomId { get; set; }
    }

}
