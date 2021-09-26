using ePM.Dal.ViewModels;
using ePM_Dal.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePM.Dal.Logic
{
    public static class BookingManager
    {
        //public static string CreateSchedule(int noofdays, DateTime Dutydate, int serviceID, int userid)
        //{
        //    string friendlyMsg = "";
        //    try
        //    {
        //        using (var db = new eMedicalEntities())
        //        {
        //            var outputMsgParameter = new ObjectParameter("msg", typeof(string));

        //            DateTime Dtt = Dutydate;
        //            for (int s = 1; s < noofdays; s++)
        //            {
        //                if ((Dtt.DayOfWeek != DayOfWeek.Friday))
        //                {
        //                    for (int i = 0; i < GetTimingList().Count; i++)
        //                    {
        //                        db.sp_eMedical_addNewBookingTiming(Dtt.AddDays(s), GetTimingList()[i].TimingBegin, GetTimingList()[i].TimingEnd, serviceID, userid, outputMsgParameter);
        //                    }
        //                }
        //            }
        //                        friendlyMsg = outputMsgParameter.Value.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        friendlyMsg = "Please contact your admin!. unexpected error";
        //        ExceptionsManager.AddException(ex);
        //        if (ex.InnerException != null)
        //        {
        //            ExceptionsManager.AddException(ex.InnerException);
        //        }
        //    }

        //    return friendlyMsg;
        //}
        public static string CreateSchedule(DateTime Dutydate, int timeFrom, int timeEnd, int roomID, int userid)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    var outputMsgParameter = new ObjectParameter("msg", typeof(string));
                    int timeFrom_minutes = timeFrom * 60;
                    int timeEnd_minutes = timeEnd * 60;
                    

                    int minutesinbetween = (timeEnd - timeFrom) * 60;
                    for (int i = 0; i < minutesinbetween; i = i + 15)
                    {
                        int hourInMinutes = checkAndReturnInteger(i);

                        db.sp_eMedical_addNewBookingTiming(Dutydate, (timeFrom_minutes + i).ToString(), (timeFrom_minutes + i + 15).ToString(), roomID, userid, i, timeFrom.ToString(), timeEnd.ToString(), (timeFrom_minutes + hourInMinutes).ToString(), (timeFrom_minutes + hourInMinutes + 60).ToString(), outputMsgParameter);
                    }
                    db.sp_eMedical_FlagAllBookingTimesBy_Room(Dutydate, roomID);
                    friendlyMsg = outputMsgParameter.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                friendlyMsg = "Please contact your admin!. unexpected error";
                ExceptionsManager.AddException(ex);
                if (ex.InnerException != null)
                {
                    ExceptionsManager.AddException(ex.InnerException);
                }
            }

            return friendlyMsg;
        }
        private static int checkAndReturnInteger(int numb)
        {
            int x = 0;
            if (numb >= 60 && numb < 120) x = 60;
            else if (numb >= 120 && numb < 180) x = 120;
            else if (numb >= 180 && numb < 240) x = 180;
            else if (numb >= 240 && numb < 300) x = 240;
            else if (numb >= 300 && numb < 360) x = 300;
            else if (numb >= 360 && numb < 420) x = 360;
            else if (numb >= 420 && numb < 480) x = 420;
            else if (numb >= 480 && numb < 540) x = 480;
            else if (numb >= 540 && numb < 600) x = 540;
            else if (numb >= 600 && numb < 180) x = 600;
            else if (numb >= 660 && numb < 660) x = 660;
            else if (numb >= 720 && numb < 720) x = 720;
            else if (numb >= 780 && numb < 780) x = 780;
            else if (numb >= 840 && numb < 840) x = 840;
            else if (numb >= 900) x = 900;
            return x;
        }
        public static String convert(int mins)
        {
            int hours = (mins - mins % 60) / 60;
            return "" + hours + ":" + (mins - hours * 60);
        }
        public static List<eMedical_Timing> GetTimingList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_Timing.Where(x => x.Status == true).ToList();
            }
        }
        public static List<vBookingTime> GetBookingTimingList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.vBookingTimes.ToList();
            }
        }
        public static List<BookingDates> GetBookingTimingList_distinct()
        {
            using (var db = new eMedicalEntities())
            {
                return db.vBookingTimes.Select(m => m.BookingDate).Distinct()
                    .Select(x => new BookingDates
                    {
                    bookingDate = x.Value
                  }).ToList(); 
            }
        }
        public static List<eMedical_BookingTiming> GetBookingTimingList_ByUserId(bool isBooked, int userid)
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_BookingTiming.Where(x => x.IsBooked == isBooked && x.UpdatedByID == userid).ToList();
            }
        }
        public static List<eMedical_BookingTiming> GetBookingTimingList_ByServiceID(bool isBooked, int servid)
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_BookingTiming.Where(x => x.IsBooked == isBooked && x.ServiceID == servid).ToList();
            }
        }
        public static List<eMedical_BookingTiming> GetBookingTimingList_ByDate(bool isBooked, DateTime Bdate)
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_BookingTiming.Where(x => x.IsBooked == isBooked && x.BookingDate == Bdate).ToList();
            }
        }
        public static bool updateBookingTimeRecord(eMedical_BookingTiming bookingTiming)
        {
            bool isUpdated = false;
            if (bookingTiming != null)
            {
                using (var db = new eMedicalEntities())
                {
                    var bookingTimeRecord = db.eMedical_BookingTiming.Where(x => x.ID == bookingTiming.ID).FirstOrDefault();
                    bookingTimeRecord.ID = bookingTiming.ID;
                    bookingTimeRecord.IsAvailable = bookingTiming.IsAvailable;
                    db.SaveChanges();
                    isUpdated = true;
                }
            }
            return isUpdated;
        }
    }
}
