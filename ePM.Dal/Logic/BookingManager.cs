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
        public static int CheckTo_DeleteBookingday(DateTime Dutydate, int roomID, int userid)
        {
            using (var db = new eMedicalEntities())
            {
                int chkMoreThanZero = db.vBookingTimesDistincts.Where(x => x.BookingDate == Dutydate && x.RoomID == roomID && x.UpdatedByID == userid).Count();
                return chkMoreThanZero;
            }

        }
        public static string CreateSchedule(DateTime Dutydate, int timeFrom, int timeEnd, int roomID, int userid)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    if (CheckTo_DeleteBookingday(Dutydate, roomID, userid) > 0)
                    {
                        db.sp_eMedical_DeleteBookingTiming(Dutydate, roomID, userid);
                    }
                    var outputMsgParameter = new ObjectParameter("msg", typeof(string));
                    int timeFrom_minutes = timeFrom * 60;
                    int timeEnd_minutes = timeEnd * 60;

                    int roomSessionDuration = db.eMedical_Room.Where(x => x.ID == roomID).FirstOrDefault().SessionDuration.Value;
                    int minutesinbetween = (timeEnd - timeFrom) * 60;
                    for (int i = 0; i < minutesinbetween; i = i + roomSessionDuration)
                    {
                        int hourInMinutes = checkAndReturnInteger(i);
                        TimeSpan spWorkMinBEGIN = TimeSpan.FromMinutes(timeFrom_minutes + i);
                        TimeSpan spWorkMinEND = TimeSpan.FromMinutes(timeFrom_minutes + i + roomSessionDuration);
                        DateTime dDatebegin = Dutydate + spWorkMinBEGIN;
                        DateTime dDateEND = Dutydate + spWorkMinEND;
                        db.sp_eMedical_addNewBookingTiming(Dutydate, dDatebegin, dDateEND, (timeFrom_minutes + i).ToString(), (timeFrom_minutes + i + roomSessionDuration).ToString(), roomID, userid, i, timeFrom.ToString(), timeEnd.ToString(), (timeFrom_minutes + hourInMinutes).ToString(), (timeFrom_minutes + hourInMinutes + 60).ToString(), outputMsgParameter);
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
            else if (numb >= 600 && numb < 660) x = 600;
            else if (numb >= 660 && numb < 720) x = 660;
            else if (numb >= 720 && numb < 780) x = 720;
            else if (numb >= 780 && numb < 840) x = 780;
            else if (numb >= 840 && numb < 900) x = 840;
            else if (numb >= 900 && numb < 960) x = 900;
            else if (numb >= 960 && numb < 1020) x = 960;
            else if (numb >= 1020 && numb < 1080) x = 1020;
            else if (numb >= 1080 && numb < 1140) x = 1080;
            else if (numb >= 1140 && numb < 1200) x = 1140;
            else if (numb >= 1200 && numb < 1260) x = 1200;
            else if (numb >= 1260 && numb < 1320) x = 1260;
            else if (numb >= 1320 && numb < 1380) x = 1320;
            else if (numb >= 1380 && numb < 1440) x = 1380;
            else if (numb >= 1440) x = 1440;
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
        public static List<vBookingTime> GetBookingTimingListbyroomid(int userId, int roomId, DateTime selectedDate)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vBookingTimes.Where(x => x.UpdatedByID == userId && x.RoomId == roomId && x.IsBooked == false && x.IsAvailable == true && x.BookingDate_TimeBegin >= DateTime.Now && x.BookingDate == selectedDate).ToList();
            }
        }
        public static List<vBookingTime> GetBookingTimingListbyroomid(int userId, int roomId, DateTime timeBegin, DateTime selectedDate)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vBookingTimes.Where(x => x.UpdatedByID == userId && x.RoomId == roomId && x.IsBooked == false && x.IsAvailable == true && x.BookingDate_TimeBegin >= timeBegin && x.BookingDate == selectedDate).ToList();
            }
        }
        //public static List<BookingDates> GetBookingTimingList_Distinct()
        //{
        //    using (var db = new eMedicalEntities())
        //    {
        //        //List<vBookingTime> bbb = new List<vBookingTime>();
        //        return db.vBookingTimes.Select(i => new { i.TimeBegins, i.TimeEnds, i.BookingDate, i.IsBooked, i.IsAvailable, i.RoomId, i.RoomName }).Distinct()
        //        .Select(x => new vBookingTime
        //        {
        //            TimeBegins = x.TimeBegins,
        //            TimeEnds = x.TimeEnds,
        //            BookingDate = x.BookingDate.Value,
        //            IsBooked = x.IsBooked.Value,
        //            IsAvailable = x.IsAvailable.Value,
        //            RoomId = x.RoomId.Value,
        //            RoomName = x.RoomName
        //        }).ToList();
        //        //bbb = db.vBookingTimes.Select(x => new vBookingTime { TimeBegins = x.TimeBegins, TimeEnds = x.TimeEnds }).Distinct().ToList();
        //        //return bbb;
        //    }
        //}
        public static List<BookingDates> GetBookingTimingList_distinct()
        {
            using (var db = new eMedicalEntities())
            {
                return db.vBookingTimesDistincts.Select(m => new { m.BookingDate, m.TimeBegins, m.TimeEnds, m.IsAvailable, m.RoomName, m.RoomID }).Distinct()
                    .Select(x => new BookingDates
                    {
                        RoomId =x.RoomID,
                        bookingDate = x.BookingDate.Value,
                        TimeBegins = x.TimeBegins,
                        TimeEnds = x.TimeEnds,
                        IsAvailable = x.IsAvailable.Value,
                        RoomName = x.RoomName
                    }).ToList();
            }
        }
        public static List<BookingDates> GetBookingTimingList_distinct(int usrId, int roomId)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vBookingTimesDistincts.Select(m => new { m.BookingDate, m.TimeBegins, m.TimeEnds, m.IsAvailable, m.RoomName, m.UpdatedByID, m.RoomID }).Distinct()
                    .Select(x => new BookingDates
                    {
                        bookingDate = x.BookingDate.Value,
                        TimeBegins = x.TimeBegins,
                        TimeEnds = x.TimeEnds,
                        IsAvailable = x.IsAvailable.Value,
                        RoomName = x.RoomName,
                        UserID = x.UpdatedByID.Value,
                        RoomId = x.RoomID
                    }).Where(k => k.UserID == usrId && k.RoomId == roomId && k.bookingDate >= DateTime.Now).ToList();
            }
        }
        public static List<BookingDates> GetBookingTimingList_distinct_Nottoday(int usrId, int roomId)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vBookingTimesDistincts.Select(m => new { m.BookingDate, m.TimeBegins, m.TimeEnds, m.IsAvailable, m.RoomName, m.UpdatedByID, m.RoomID }).Distinct()
                    .Select(x => new BookingDates
                    {
                        bookingDate = x.BookingDate.Value,
                        TimeBegins = x.TimeBegins,
                        TimeEnds = x.TimeEnds,
                        IsAvailable = x.IsAvailable.Value,
                        RoomName = x.RoomName,
                        UserID = x.UpdatedByID.Value,
                        RoomId = x.RoomID
                    }).Where(k => k.UserID == usrId && k.RoomId == roomId).ToList();
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
        public static List<vAppointment> GetAppointmentList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.vAppointments.Where(x => x.CheckIN == false).ToList();
            }
        }
        public static List<vAppointment> GetBookingAppointmentList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.vAppointments.Where(x => x.CheckIN == false).ToList();
            }
        }
        public static List<vBookingAppointment> GetBookingTimesList(DateTime bookingShortDate, int roomID)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vBookingAppointments.Where(x => x.BookingDate == bookingShortDate && x.RoomId == roomID).ToList();
            }
        }
        public static List<vAppointment> GetDoctorAppointmentList(int doctorRoomId)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vAppointments.Where(x => x.RoomId == doctorRoomId).ToList();
            }
        }
        public static int GetServiceDuration(int serviceId)
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_Service.Where(x => x.ID == serviceId).FirstOrDefault().NoofSessions.Value;
            }
        }
        public static bool SessionIsBooked(int serviceId, int roomId, DateTime timeStart)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vBookingAppointments.Where(x => x.RoomId == roomId && x.ServiceID == serviceId && x.BookingDate_TimeBegin == timeStart).FirstOrDefault().IsBooked.Value;
            }
        }
        public static string AddNewAppointment(DateTime startTime, DateTime endTime, int patientId, int roomId, int serviceID)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    bool booked = false;
                    //int hasRecord = 0;
                    for (DateTime i = startTime; i < endTime; i = i.AddMinutes(15))
                    {
                        //hasRecord = db.vBookingTimes.Where(x => x.RoomId == roomId && x.BookingDate_TimeBegin == startTime).ToList().Count;
                        //if (hasRecord > 0)
                        //{

                        booked = db.vBookingAppointments.Where(x => x.RoomId == roomId && x.BookingDate_TimeBegin == startTime).FirstOrDefault().IsBooked.Value;
                        if (booked) break;
                        //}
                    }

                    if (!booked)
                    {
                        var outputMsgParameter = new ObjectParameter("msg", typeof(string));
                        for (DateTime i = startTime; i < endTime; i = i.AddMinutes(15))
                        {
                            db.sp_eMedical_UpdateBookAppointment(i, roomId, outputMsgParameter);
                        }
                        db.sp_eMedical_BookAppointment(startTime, endTime, roomId, patientId, serviceID, outputMsgParameter);
                        friendlyMsg = outputMsgParameter.Value.ToString();
                    }
                    else
                    {
                        friendlyMsg = "This time has booked before";
                    }
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
    }
}
