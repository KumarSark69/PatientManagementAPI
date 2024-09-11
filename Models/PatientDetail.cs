using System.ComponentModel.DataAnnotations;

namespace PatientManagementApi.Models
{
    public class PatientDetail
    {
        [Key]
        public int DetailID { get; set; }
        public int PatientID { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentHistory { get; set; }
        public string Medications { get; set; }
        public string Allergies { get; set; }
        public string Notes { get; set; }
    }
}
