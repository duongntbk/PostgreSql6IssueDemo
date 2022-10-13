namespace DbSetup
{
    // EFCore uses this class to discover and create DomainContext
    public class DomainContextFactory : IDesignTimeDbContextFactory<DomainContext>
    {
        public DomainContext CreateDbContext(string[] args) => DomainContext.Create(CONSTR);
    }
}
