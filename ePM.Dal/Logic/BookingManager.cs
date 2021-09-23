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
                    int howManyHours = timeEnd - timeFrom;
                    int howManyMinutes = howManyHours * 60;
                    for (int i = 0; i < howManyMinutes; i = i + 15)
                    {
                        timeFrom = timeFrom + i;
                        timeEnd = timeEnd + i + 15;

                        db.sp_eMedical_addNewBookingTiming(Dutydate, timeFrom.ToString(), timeEnd.ToString(), roomID, userid, i, outputMsgParameter);
                    }
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
    }
}
