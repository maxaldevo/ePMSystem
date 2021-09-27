using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePM.Dal.ViewModels
{
    public class BookingDates
    {
        public int ID { get; set; }
        public DateTime bookingDate { get; set; }
        public string TimeBegins { get; set; }
        public string TimeEnds { get; set; }
        public bool IsBooked { get; set; }
        public bool IsAvailable { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
    }
}
