using System.Collections;

namespace P04.WorkForce.Models
{
    public class JobArrayList : ArrayList
    {
        public void AddJob(Job job)
        {
            this.Add(job);

            job.JobDone += this.OnJobDone;
        }

        private void OnJobDone(Job job)
        {
            this.Remove(job);
        }
    }
}
