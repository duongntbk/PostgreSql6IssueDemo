namespace Net6;

public class DomainContext : DbContext
{
    public DomainContext(DbContextOptions<DomainContext> options)
        : base(options)
    {
    }

    public static DomainContext Create(string conStr)
    {
        var optionBuilder = new DbContextOptionsBuilder<DomainContext>();
        optionBuilder.UseNpgsql(conStr, db => db.MigrationsAssembly("DbSetup"));
        return new DomainContext(optionBuilder.Options);
    }

    public virtual DbSet<Person> People { get; set; }
}
