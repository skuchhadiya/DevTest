using DeveloperTest.Models;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface IJobService
    {
        Task<JobModel[]> GetJobs();

        Task<JobModel> GetJob(int jobId);

        Task<JobModel> CreateJob(BaseJobModel model);
    }
}
