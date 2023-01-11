using HandOffApiCli.Data;
using HandOffApiCli.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandOffApiCli.Services
{
    public interface IPatientService
    {
        Task<List<Patient>?> GetAllPatients();
        Task<Patient?> GetSinglePatient(int id);
        Task<Patient> AddPatient(Patient patient);
        Task<List<Patient>?> UpdatePatient(int id, Patient request);
        Task<List<Patient>?> DeletePatient(int id);
        Task<Patient?> AddPrimaryDoctorToPatient(int id, int employeeId);
        Task<Employee> GetPatientPrimaryDoctor(int patientId);
    }
    public class PatientService : IPatientService
    {
        private readonly HandOffContext _context;
        public PatientService(HandOffContext context)
        {
            _context = context;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            if (patient.PatientFirstName != null)
            {
                await _context.AddAsync(patient);
                await _context.SaveChangesAsync();
                return patient;
            }
            patient.PatientFirstName = "Jane";
            patient.PatientLastName = "Doe";
            await _context.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<List<Patient>?> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient is null)
                return null;

            _context.Patients.Remove(patient);

            await _context.SaveChangesAsync();
            return await GetAllPatients();
        }

        public async Task<List<Patient>?> GetAllPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetSinglePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient is null)
                return null;
            return patient;
        }

        public async Task<List<Patient>?> UpdatePatient(int id, Patient request)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient is null)
                return null;

            patient.PatientFirstName = patient.PatientFirstName;
            patient.PatientFirstName = request.PatientFirstName;
            await _context.SaveChangesAsync();

            return await GetAllPatients();
        }

        public async Task<Patient?> AddPrimaryDoctorToPatient(int id, int employeeId)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient is null)
                return null;
            var employee = await _context.Employees.FindAsync(employeeId);
            patient.Employees.EmployeeId = employeeId;
            await _context.SaveChangesAsync();
            return patient;

        }

        public async Task<Employee?> GetPatientPrimaryDoctor(int patientId)
        {
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient is null)
                return null;
            var employee = await _context.Employees.FindAsync(patient.Employees.EmployeeId);
            if ( employee is null)
            {
                return null;
            }
            return employee;
        }
    }
}