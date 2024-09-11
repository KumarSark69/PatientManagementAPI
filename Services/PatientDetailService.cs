using PatientManagementApi.Models;
using PatientManagementApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientManagementApi.Services
{
    public class PatientDetailService : IPatientDetailService
    {
        private readonly IPatientDetailRepository _patientDetailRepository;

        public PatientDetailService(IPatientDetailRepository patientDetailRepository)
        {
            _patientDetailRepository = patientDetailRepository;
        }

        public async Task<IEnumerable<PatientDetail>> GetAllPatientDetailsAsync()
        {
           
            return await _patientDetailRepository.GetAllPatientDetailsAsync();
        }

        public async Task<PatientDetail> GetPatientDetailByIdAsync(int id)
        {
            return await _patientDetailRepository.GetPatientDetailByIdAsync(id);
        }

        public async Task<IEnumerable<PatientDetail>> GetPatientDetailsByPatientIdAsync(int patientId)
        {
            return await _patientDetailRepository.GetPatientDetailsByPatientIdAsync(patientId);
        }

        public async Task<PatientDetail> AddPatientDetailAsync(PatientDetail patientDetail)
        {
            return await _patientDetailRepository.AddPatientDetailAsync(patientDetail);
        }

        public async Task UpdatePatientDetailAsync(PatientDetail patientDetail)
        {
            await _patientDetailRepository.UpdatePatientDetailAsync(patientDetail);
        }

        public async Task DeletePatientDetailAsync(int id)
        {
            await _patientDetailRepository.DeletePatientDetailAsync(id);
        }
    }
}