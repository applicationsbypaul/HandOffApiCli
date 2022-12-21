using HandOffApiCli.Data;
using HandOffApiCli.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandOffApiCli.Services
{
    public interface IJobDetailService
    {
        Task<List<JobDetail>?> GetAllJobDetails();
        Task<JobDetail?> GetSingleJobDetail(int id);
        Task<JobDetail> AddJobDetail(JobDetail jobDetail);
        Task<List<JobDetail>?> DeleteJobDetail(int id);
    }
    public class JobDetailService: IJobDetailService
    {
        private readonly HandOffContext _context;

        public JobDetailService(HandOffContext context)
        {
            _context = context;
        }

        public async Task<List<JobDetail>?> GetAllJobDetails() => await _context.JobDetails.ToListAsync();

        public async Task<JobDetail?> GetSingleJobDetail(int id)
        {
            var jobDetail = await _context.JobDetails.FindAsync(id);
            if (jobDetail is null)
                return null;
            return jobDetail;
        }

        public async Task<JobDetail> AddJobDetail(JobDetail jobDetail)
        {
            await _context.AddAsync(jobDetail);
            await _context.SaveChangesAsync();
            return jobDetail;
        }

        public async Task<List<JobDetail>?> DeleteJobDetail(int id)
        {
            var jobDetail = await _context.JobDetails.FindAsync(id);
            if (jobDetail is null)
                return null;

            _context.JobDetails.Remove(jobDetail);

            await _context.SaveChangesAsync();
            return await GetAllJobDetails();
        }
    }
}
