﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ePM.Dal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class eMedicalEntities : DbContext
    {
        public eMedicalEntities()
            : base("name=eMedicalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<eMedical_Pages> eMedical_Pages { get; set; }
        public virtual DbSet<eMedical_Roles> eMedical_Roles { get; set; }
        public virtual DbSet<eMedical_RolesRights> eMedical_RolesRights { get; set; }
        public virtual DbSet<eMedical_Clinic> eMedical_Clinic { get; set; }
        public virtual DbSet<eMedical_Hospital> eMedical_Hospital { get; set; }
        public virtual DbSet<eMedical_User> eMedical_User { get; set; }
        public virtual DbSet<vPersonnel> vPersonnels { get; set; }
        public virtual DbSet<v_RoleGroups> v_RoleGroups { get; set; }
        public virtual DbSet<v_userRoles> v_userRoles { get; set; }
        public virtual DbSet<v_eMedical_ModulePages> v_eMedical_ModulePages { get; set; }
        public virtual DbSet<v_eMedical_RolesCount> v_eMedical_RolesCount { get; set; }
        public virtual DbSet<eMedical_Product> eMedical_Product { get; set; }
        public virtual DbSet<vProductInfo> vProductInfoes { get; set; }
        public virtual DbSet<eMedical_Service> eMedical_Service { get; set; }
        public virtual DbSet<eMedical_ServiceType> eMedical_ServiceType { get; set; }
        public virtual DbSet<vService> vServices { get; set; }
        public virtual DbSet<vServiceType> vServiceTypes { get; set; }
        public virtual DbSet<eMedical_BookingTiming> eMedical_BookingTiming { get; set; }
        public virtual DbSet<eMedical_Timing> eMedical_Timing { get; set; }
        public virtual DbSet<eMedical_Room> eMedical_Room { get; set; }
        public virtual DbSet<u_HRRoles> u_HRRoles { get; set; }
        public virtual DbSet<v_GroupsPersonnel> v_GroupsPersonnel { get; set; }
        public virtual DbSet<LMS_ExceptionLog> LMS_ExceptionLog { get; set; }
        public virtual DbSet<vBookingTime> vBookingTimes { get; set; }
    
        public virtual int sp_eMedical_addNewUser(string fName, string firstName, string lastName, string email, string mobile, string empNo, Nullable<int> roleId, ObjectParameter msg)
        {
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var mobileParameter = mobile != null ?
                new ObjectParameter("Mobile", mobile) :
                new ObjectParameter("Mobile", typeof(string));
    
            var empNoParameter = empNo != null ?
                new ObjectParameter("EmpNo", empNo) :
                new ObjectParameter("EmpNo", typeof(string));
    
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eMedical_addNewUser", fNameParameter, firstNameParameter, lastNameParameter, emailParameter, mobileParameter, empNoParameter, roleIdParameter, msg);
        }
    
        public virtual int sp_eMedical_addNewHospital(string hospitalName, string description, Nullable<int> userID, ObjectParameter msg)
        {
            var hospitalNameParameter = hospitalName != null ?
                new ObjectParameter("hospitalName", hospitalName) :
                new ObjectParameter("hospitalName", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eMedical_addNewHospital", hospitalNameParameter, descriptionParameter, userIDParameter, msg);
        }
    
        public virtual int sp_eMedical_addNewClinic(string clinicName, Nullable<int> hospitalID, Nullable<int> userID, ObjectParameter msg)
        {
            var clinicNameParameter = clinicName != null ?
                new ObjectParameter("clinicName", clinicName) :
                new ObjectParameter("clinicName", typeof(string));
    
            var hospitalIDParameter = hospitalID.HasValue ?
                new ObjectParameter("hospitalID", hospitalID) :
                new ObjectParameter("hospitalID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eMedical_addNewClinic", clinicNameParameter, hospitalIDParameter, userIDParameter, msg);
        }
    
        public virtual int sp_eMedical_addNewUser_ByHospitalID_ClinicID(string fName, string firstName, string lastName, string email, string mobile, string empNo, Nullable<int> roleId, Nullable<int> hospitalId, Nullable<int> clinicId, ObjectParameter msg)
        {
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var mobileParameter = mobile != null ?
                new ObjectParameter("Mobile", mobile) :
                new ObjectParameter("Mobile", typeof(string));
    
            var empNoParameter = empNo != null ?
                new ObjectParameter("EmpNo", empNo) :
                new ObjectParameter("EmpNo", typeof(string));
    
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            var hospitalIdParameter = hospitalId.HasValue ?
                new ObjectParameter("HospitalId", hospitalId) :
                new ObjectParameter("HospitalId", typeof(int));
    
            var clinicIdParameter = clinicId.HasValue ?
                new ObjectParameter("ClinicId", clinicId) :
                new ObjectParameter("ClinicId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eMedical_addNewUser_ByHospitalID_ClinicID", fNameParameter, firstNameParameter, lastNameParameter, emailParameter, mobileParameter, empNoParameter, roleIdParameter, hospitalIdParameter, clinicIdParameter, msg);
        }
    
        public virtual ObjectResult<sp_eMedical_ModulePagesByRole_Result> sp_eMedical_ModulePagesByRole(Nullable<int> roleId)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_eMedical_ModulePagesByRole_Result>("sp_eMedical_ModulePagesByRole", roleIdParameter);
        }
    
        public virtual ObjectResult<sp_eMedical_GetPagesByRole_Result> sp_eMedical_GetPagesByRole(Nullable<int> roleId, Nullable<int> level)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            var levelParameter = level.HasValue ?
                new ObjectParameter("Level", level) :
                new ObjectParameter("Level", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_eMedical_GetPagesByRole_Result>("sp_eMedical_GetPagesByRole", roleIdParameter, levelParameter);
        }
    
        public virtual int sp_eMedical_addNewProduct_ByHospitalID_ClinicID(string pName, Nullable<int> qty, Nullable<int> costPrice, Nullable<int> profitPrice, Nullable<int> salePrice, Nullable<int> userId, Nullable<int> hospitalId, Nullable<int> clinicId, ObjectParameter msg)
        {
            var pNameParameter = pName != null ?
                new ObjectParameter("PName", pName) :
                new ObjectParameter("PName", typeof(string));
    
            var qtyParameter = qty.HasValue ?
                new ObjectParameter("Qty", qty) :
                new ObjectParameter("Qty", typeof(int));
    
            var costPriceParameter = costPrice.HasValue ?
                new ObjectParameter("CostPrice", costPrice) :
                new ObjectParameter("CostPrice", typeof(int));
    
            var profitPriceParameter = profitPrice.HasValue ?
                new ObjectParameter("ProfitPrice", profitPrice) :
                new ObjectParameter("ProfitPrice", typeof(int));
    
            var salePriceParameter = salePrice.HasValue ?
                new ObjectParameter("SalePrice", salePrice) :
                new ObjectParameter("SalePrice", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var hospitalIdParameter = hospitalId.HasValue ?
                new ObjectParameter("HospitalId", hospitalId) :
                new ObjectParameter("HospitalId", typeof(int));
    
            var clinicIdParameter = clinicId.HasValue ?
                new ObjectParameter("ClinicId", clinicId) :
                new ObjectParameter("ClinicId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eMedical_addNewProduct_ByHospitalID_ClinicID", pNameParameter, qtyParameter, costPriceParameter, profitPriceParameter, salePriceParameter, userIdParameter, hospitalIdParameter, clinicIdParameter, msg);
        }
    
        public virtual int sp_eMedical_addNewSession_ByHospitalID_ClinicID(string sName, Nullable<int> serviceTypeID, Nullable<int> noofSessions, Nullable<int> price, Nullable<int> userId, Nullable<int> hospitalId, Nullable<int> clinicId, Nullable<int> roomId, ObjectParameter msg)
        {
            var sNameParameter = sName != null ?
                new ObjectParameter("SName", sName) :
                new ObjectParameter("SName", typeof(string));
    
            var serviceTypeIDParameter = serviceTypeID.HasValue ?
                new ObjectParameter("ServiceTypeID", serviceTypeID) :
                new ObjectParameter("ServiceTypeID", typeof(int));
    
            var noofSessionsParameter = noofSessions.HasValue ?
                new ObjectParameter("NoofSessions", noofSessions) :
                new ObjectParameter("NoofSessions", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var hospitalIdParameter = hospitalId.HasValue ?
                new ObjectParameter("HospitalId", hospitalId) :
                new ObjectParameter("HospitalId", typeof(int));
    
            var clinicIdParameter = clinicId.HasValue ?
                new ObjectParameter("ClinicId", clinicId) :
                new ObjectParameter("ClinicId", typeof(int));
    
            var roomIdParameter = roomId.HasValue ?
                new ObjectParameter("roomId", roomId) :
                new ObjectParameter("roomId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eMedical_addNewSession_ByHospitalID_ClinicID", sNameParameter, serviceTypeIDParameter, noofSessionsParameter, priceParameter, userIdParameter, hospitalIdParameter, clinicIdParameter, roomIdParameter, msg);
        }
    
        public virtual int sp_eMedical_addNewSessionType(string serviceType, Nullable<int> userId, ObjectParameter msg)
        {
            var serviceTypeParameter = serviceType != null ?
                new ObjectParameter("ServiceType", serviceType) :
                new ObjectParameter("ServiceType", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eMedical_addNewSessionType", serviceTypeParameter, userIdParameter, msg);
        }
    
        public virtual int sp_eMedical_addNewBookingTiming(Nullable<System.DateTime> bookingDate, string bookingTimeBegin, string bookingTimeEnd, Nullable<int> roomID, Nullable<int> userID, Nullable<int> timingSerial, string timeBegins, string timeEnds, string timeByHourBegins, string timeByHourEnds, ObjectParameter msg)
        {
            var bookingDateParameter = bookingDate.HasValue ?
                new ObjectParameter("BookingDate", bookingDate) :
                new ObjectParameter("BookingDate", typeof(System.DateTime));
    
            var bookingTimeBeginParameter = bookingTimeBegin != null ?
                new ObjectParameter("BookingTimeBegin", bookingTimeBegin) :
                new ObjectParameter("BookingTimeBegin", typeof(string));
    
            var bookingTimeEndParameter = bookingTimeEnd != null ?
                new ObjectParameter("BookingTimeEnd", bookingTimeEnd) :
                new ObjectParameter("BookingTimeEnd", typeof(string));
    
            var roomIDParameter = roomID.HasValue ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var timingSerialParameter = timingSerial.HasValue ?
                new ObjectParameter("timingSerial", timingSerial) :
                new ObjectParameter("timingSerial", typeof(int));
    
            var timeBeginsParameter = timeBegins != null ?
                new ObjectParameter("TimeBegins", timeBegins) :
                new ObjectParameter("TimeBegins", typeof(string));
    
            var timeEndsParameter = timeEnds != null ?
                new ObjectParameter("TimeEnds", timeEnds) :
                new ObjectParameter("TimeEnds", typeof(string));
    
            var timeByHourBeginsParameter = timeByHourBegins != null ?
                new ObjectParameter("TimeByHourBegins", timeByHourBegins) :
                new ObjectParameter("TimeByHourBegins", typeof(string));
    
            var timeByHourEndsParameter = timeByHourEnds != null ?
                new ObjectParameter("TimeByHourEnds", timeByHourEnds) :
                new ObjectParameter("TimeByHourEnds", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eMedical_addNewBookingTiming", bookingDateParameter, bookingTimeBeginParameter, bookingTimeEndParameter, roomIDParameter, userIDParameter, timingSerialParameter, timeBeginsParameter, timeEndsParameter, timeByHourBeginsParameter, timeByHourEndsParameter, msg);
        }
    
        public virtual int sp_eMedical_addNewRoom(string roomName, Nullable<int> userID, ObjectParameter msg)
        {
            var roomNameParameter = roomName != null ?
                new ObjectParameter("roomName", roomName) :
                new ObjectParameter("roomName", typeof(string));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eMedical_addNewRoom", roomNameParameter, userIDParameter, msg);
        }
    
        public virtual int sp_eMedical_FlagAllBookingTimesBy_Room(Nullable<System.DateTime> bookingDate, Nullable<int> roomID)
        {
            var bookingDateParameter = bookingDate.HasValue ?
                new ObjectParameter("BookingDate", bookingDate) :
                new ObjectParameter("BookingDate", typeof(System.DateTime));
    
            var roomIDParameter = roomID.HasValue ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eMedical_FlagAllBookingTimesBy_Room", bookingDateParameter, roomIDParameter);
        }
    }
}
