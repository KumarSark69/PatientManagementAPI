using Microsoft.EntityFrameworkCore;
using PatientManagementApi.Models;

namespace PatientManagementApi.Data
{
    public class PatientDetailsContext : DbContext
    {
        public PatientDetailsContext(DbContextOptions<PatientDetailsContext> options) : base(options) { }

        public DbSet<PatientDetail> PatientDetails { get; set; }

    }
}
