using PatientManagementApi.Models;
using PatientManagementApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientManagementApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllPatientsAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }

        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            return await _patientRepository.AddPatientAsync(patient);
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            await _patientRepository.UpdatePatientAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.DeletePatientAsync(id);
        }
    }
}