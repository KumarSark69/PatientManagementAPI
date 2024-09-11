using Microsoft.EntityFrameworkCore;
using PatientManagementApi.Data;
using PatientManagementApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementApi.Repositories
{
    public class PatientDetailRepository : IPatientDetailRepository
    {
        private readonly PatientDetailsContext _context;

        public PatientDetailRepository(PatientDetailsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientDetail>> GetAllPatientDetailsAsync()
        {
            return await _context.PatientDetails.ToListAsync();
        }

        public async Task<PatientDetail> GetPatientDetailByIdAsync(int id)
        {
            return await _context.PatientDetails.FindAsync(id);
        }

        public async Task<IEnumerable<PatientDetail>> GetPatientDetailsByPatientIdAsync(int patientId)
        {
            return await _context.PatientDetails.Where(pd => pd.PatientID == patientId).ToListAsync();
        }

        public async Task<PatientDetail> AddPatientDetailAsync(PatientDetail patientDetail)
        {
            _context.PatientDetails.Add(patientDetail);
            await _context.SaveChangesAsync();
            return patientDetail;
        }

        public async Task UpdatePatientDetailAsync(PatientDetail patientDetail)
        {
            _context.Entry(patientDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatientDetailAsync(int id)
        {
            var patientDetail = await _context.PatientDetails.FindAsync(id);
            if (patientDetail != null)
            {
                _context.PatientDetails.Remove(patientDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}