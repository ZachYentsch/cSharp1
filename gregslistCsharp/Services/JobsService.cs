using gregslistCsharp.Db;
using gregslistCsharp.Models;

namespace gregslistCsharp.Services
{
    public class JobsService
    {
        internal List<Job> getAll()
        {
            return RealDb.Jobs;
        }

        internal Job getById(string? jobId)
        {
            Job? foundJob = RealDb.Jobs.Find(j => j.Id == jobId);
            if (foundJob == null)
            {
                throw new Exception("Job not FOund!");
            }
            return foundJob;
        }

        internal Job Create(Job newJob)
        {
            RealDb.Jobs.Add(newJob);
            return newJob;
        }

        internal Job Edit(Job editedJob, string jobId)
        {
            Job originalJob = getById(jobId);
            originalJob.Position = editedJob.Position != null ? editedJob.Position : originalJob.Position;
            originalJob.Company = editedJob.Company != null ? editedJob.Company : originalJob.Company;
            originalJob.Description = editedJob.Description != null ? editedJob.Description : originalJob.Description;
            originalJob.Hours = editedJob.Hours != 0 ? editedJob.Hours : originalJob.Hours;
            originalJob.Pay = editedJob.Pay != 0 ? editedJob.Pay : originalJob.Pay;
            return originalJob;
        }

        internal Job Remove(string jobId)
        {
            Job foundJob = getById(jobId);
            RealDb.Jobs.Remove(foundJob);
            return foundJob;
        }
    }
}