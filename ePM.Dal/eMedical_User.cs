//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class eMedical_User
    {
        public int ID { get; set; }
        public Nullable<int> PersonnelID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<int> ReportingTo { get; set; }
        public string Qualification { get; set; }
        public string Major { get; set; }
        public string University { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public string ProfilePicPath { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string FName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NickName { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string BirthCountry { get; set; }
        public string Gender { get; set; }
        public string Citizenship { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public string TaxFileNo { get; set; }
        public string TaxCountry { get; set; }
        public string HealthInsNo { get; set; }
        public string Allergies { get; set; }
        public string USINo { get; set; }
        public string Experience { get; set; }
        public string EmployeeType { get; set; }
        public string HomePort { get; set; }
        public string PointofHire { get; set; }
        public string PointofHireAlt { get; set; }
        public string AirportDistance { get; set; }
        public string MainLanguage { get; set; }
        public string OtherLanguage { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string POAddr1 { get; set; }
        public string POAddr2 { get; set; }
        public string POSuburb { get; set; }
        public string POState { get; set; }
        public string POPostcode { get; set; }
        public string POCountry { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Mobile { get; set; }
        public string Status { get; set; }
        public string EmployeeNo { get; set; }
        public string Company { get; set; }
        public string Notes { get; set; }
        public string Photo { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> HospitalID { get; set; }
        public Nullable<int> ClinicID { get; set; }
    
        public virtual eMedical_Roles eMedical_Roles { get; set; }
        public virtual eMedical_Clinic eMedical_Clinic { get; set; }
        public virtual eMedical_Hospital eMedical_Hospital { get; set; }
    }
}