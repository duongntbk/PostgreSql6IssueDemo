namespace Net6;

public class DomainContextLegacy : DbContext
{
    public DomainContextLegacy(DbContextOptions<DomainContextLegacy> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public static DomainContextFixed Create(string conStr)
    {
        var optionBuilder = new DbContextOptionsBuilder<DomainContextFixed>();
        optionBuilder.UseNpgsql(conStr, db => db.MigrationsAssembly("DbSetup"));
        return new DomainContextFixed(optionBuilder.Options);
    }

    public virtual DbSet<Person> People { get; set; }
}
