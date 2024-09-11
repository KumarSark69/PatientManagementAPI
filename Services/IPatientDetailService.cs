using PatientManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientManagementApi.Services
{
    public interface IPatientDetailService
    {
        Task<IEnumerable<PatientDetail>> GetAllPatientDetailsAsync();
        Task<PatientDetail> GetPatientDetailByIdAsync(int id);
        Task<IEnumerable<PatientDetail>> GetPatientDetailsByPatientIdAsync(int patientId);
        Task<PatientDetail> AddPatientDetailAsync(PatientDetail patientDetail);
        Task UpdatePatientDetailAsync(PatientDetail patientDetail);
        Task DeletePatientDetailAsync(int id);
    }
}
