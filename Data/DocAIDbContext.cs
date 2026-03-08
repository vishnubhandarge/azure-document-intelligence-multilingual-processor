using Azure_AI_DocumentProcessor.Modals;
using Microsoft.EntityFrameworkCore;

namespace Azure_AI_DocumentProcessor.Data
{
    public class DocAIDbContext : DbContext
    {
        public DocAIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Peoples { get; set; }
    }
}
