using HandOffApiCli.Data;
using HandOffApiCli.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection.Metadata.Ecma335;

namespace HandOffApiCli.Services
{
    public interface IHandoffService
    {
        Task<Handoff> AddHandoff(Handoff handoff);
        Task<List<Handoff>> GetAllHandoffs();
        Task<Handoff?> GetSingleHandoff(int id);
        Task<Handoff?> UpdateHandoff(int id, Handoff request);
    }
    public class HandoffService : IHandoffService
    {
        private readonly HandOffContext _context;

        public HandoffService(HandOffContext context)
        {
            _context = context;
        }

        public async Task<Handoff> AddHandoff(Handoff handoff)
        {
            await _context.AddAsync(handoff);
            await _context.SaveChangesAsync();
            return handoff;
        }

        public async Task<List<Handoff>> GetAllHandoffs()
        {
            return await _context.Handoffs.ToListAsync();
        }

        public async Task<Handoff?> GetSingleHandoff(int id)
        {
            return await _context.Handoffs.FindAsync(id);
        }

        public async Task<Handoff?> UpdateHandoff(int id, Handoff request)
        {
            await _context.Handoffs.Where(x => x.Handoffid == id)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Handoff_Employee_CurrentId, request.Handoff_Employee_CurrentId)
                .SetProperty(x => x.Handoff_Employee_NextId, request.Handoff_Employee_NextId)
                .SetProperty(x => x.HandoffExecution, request.HandoffExecution));
            return await GetSingleHandoff(id);

        }
    }
}
