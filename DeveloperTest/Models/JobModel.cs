using System;

namespace DeveloperTest.Models
{
    //JobModel can extend BaseJobModel so we avoid engineer and when prop re-declaration
    public class JobModel
    {
        public int  JobId { get; set; }

        public string Engineer { get; set; }

        public DateTime When { get; set; }

        public virtual CustomerModel Customer { get; set; }
    }
}
