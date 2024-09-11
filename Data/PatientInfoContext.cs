using Microsoft.EntityFrameworkCore;
using PatientManagementApi.Models;

namespace PatientManagementApi.Data
{
    public class PatientInfoContext : DbContext
    {
        public PatientInfoContext(DbContextOptions<PatientInfoContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }

     
    }
}