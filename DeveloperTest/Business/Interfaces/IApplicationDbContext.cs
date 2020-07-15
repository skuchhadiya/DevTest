using DeveloperTest.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Database
{
    public interface IApplicationDbContext 
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Job> Jobs { get; set; }
    }
}