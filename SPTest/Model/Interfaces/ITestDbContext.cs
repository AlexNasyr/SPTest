using Microsoft.EntityFrameworkCore;
using SPTest.Model.TestDb;

namespace SPTest.Model {
    public interface ITestDbContext {
        DbSet<EventLog> EventLogs { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductVersion> ProductVersions { get; set; }
    }
}
