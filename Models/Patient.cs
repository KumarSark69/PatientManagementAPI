// Models/Patient.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementApi.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
      
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
   
        public string Address { get; set; }
       
        public string PhoneNumber { get; set; }
       
        public string Email { get; set; }
     
        public string MedicalRecordNumber { get; set; }
    }
}