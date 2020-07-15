using DeveloperTest.Database.Models;
using System;

namespace DeveloperTest.Models
{
    public class BaseJobModel
    {
        public string Engineer { get; set; }

        public DateTime When { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
