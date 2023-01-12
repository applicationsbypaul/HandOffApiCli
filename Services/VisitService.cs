using HandOffApiCli.Data;
using HandOffApiCli.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandOffApiCli.Services
{
    public interface IVisitService
    {
        Task<List<Visit>?> GetAllVisits();
        Task<Visit?> GetSingleVisit(int id);
        Task<Visit> AddVisit(int patientId, Visit visit);
        Task<List<Visit>?> DeleteVisit(int id);
    }
    public class VisitService : IVisitService
    {
        private readonly HandOffContext _context;

        public VisitService(HandOffContext context)
        {
            _context = context;
        }
        public async Task<List<Visit>?> GetAllVisits()
        {
            return await _context.Visits.ToListAsync();
        }
        public async Task<Visit?> GetSingleVisit(int id)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit is null)
                return null;
            return visit;
        }
        public async Task<List<Visit>?> DeleteVisit(int id)
        {
            var visitToDelete = await _context.Visits.FindAsync(id);
            if (visitToDelete is null)
                return null;
            _context.Visits.Remove(visitToDelete);
            
            await _context.SaveChangesAsync();
            return await GetAllVisits();
        }

        public async Task<Visit> AddVisit(int patientId, Visit visit)
        {
            visit.Visit_PatientId = patientId;
            await _context.AddAsync(visit);
            await _context.SaveChangesAsync();
            return visit;
        }

    }
}
