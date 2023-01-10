using HandOffApiCli.Data;
using HandOffApiCli.Data.Entities;

namespace HandOffApiCli.Services
{
    public interface IVisitService
    {
        Task<List<Visit>?> GetAllVisits();
        Task<Visit?> GetSingleVisit(int id);
        Task<Visit> AddVisit(Visit visit);
        Task<List<Visit>?> DeleteVisit(int id);
    }
    public class VisitService : IVisitService
    {
        private readonly HandOffContext _context;

        public VisitService(HandOffContext context)
        {
            _context = context;
        }

        public Task<Visit> AddVisit(Visit visit)
        {
            throw new NotImplementedException();
        }

        public Task<List<Visit>?> DeleteVisit(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Visit>?> GetAllVisits()
        {
            throw new NotImplementedException();
        }

        public Task<Visit?> GetSingleVisit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
